import 'package:assignment_d01/components/commit_button.dart';
import 'package:assignment_d01/components/critical_directives_queue.dart';
import 'package:assignment_d01/components/filter_section.dart';
import 'package:assignment_d01/components/profile_card.dart';
import 'package:assignment_d01/components/progress_section.dart';
import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        backgroundColor: Colors.white,
        surfaceTintColor: Colors.transparent,
        shadowColor: Colors.black.withValues(alpha: 0.3),
        elevation: 4,

        title: const Center(
          child: Text(
            "Task Analytics Workspace",
            style: TextStyle(
              fontSize: 24,
              fontWeight: FontWeight.w600,
            ),
          ),
        ),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            children: [
              ProfileCard(),
              const SizedBox(height: 25),
              FilterSection(),
              ProgressSection(),
              const SizedBox(height: 25),
              CriticalDirectivesQueue(),
              CommitButton(),
            ],
          ),
        ),
      ),
    );
  }
}
