import 'package:assignment_d05/features/auth/cubit/auth_state.dart';
import 'package:assignment_d05/features/auth/data/models/user_model.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AuthCubit extends Cubit<AuthState> {
  AuthCubit() : super(AuthInitial());

  final FirebaseAuth _auth = FirebaseAuth.instance;
  final FirebaseFirestore _firestore = FirebaseFirestore.instance;

  Future<void> signup({
    required String name,
    required String email,
    required String password,
  }) async {
    emit(AuthLoading());

    try {
      UserCredential credential = await _auth.createUserWithEmailAndPassword(
        email: email,
        password: password,
      );

      UserModel newUser = UserModel(
        username: name,
        email: email,
        id: credential.user!.uid,
      );

      await _firestore.collection('users').doc(newUser.id).set(newUser.toMap());

      emit(AuthSuccess(newUser));
    } on FirebaseAuthException catch (e) {
      emit(AuthError(e.message ?? "Signup failed"));
    } catch (e) {
      emit(AuthError(e.toString()));
    }
  }

  Future<void> login({required String email, required String password}) async {
    emit(AuthLoading());

    try {
      UserCredential credential = await _auth.signInWithEmailAndPassword(
        email: email,
        password: password,
      );

      DocumentSnapshot userDoc = await _firestore
          .collection('users')
          .doc(credential.user!.uid)
          .get();

      if (userDoc.exists) {
        UserModel loggedUser = UserModel.fromMap(
          userDoc.data() as Map<String, dynamic>,
        );
        emit(AuthSuccess(loggedUser));
      } else {
        emit(AuthError("User not found"));
      }
    } on FirebaseAuthException catch (e) {
      emit(AuthError(e.message ?? "Login failed"));
    } catch (e) {
      emit(AuthError(e.toString()));
    }
  }
}
