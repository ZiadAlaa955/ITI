import 'package:assignment_d04/components/buttons/clear_filters_button.dart';
import 'package:flutter/material.dart';

class NotFoundMessage extends StatelessWidget {
  const NotFoundMessage({super.key, this.onPressed});
  final void Function()? onPressed;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Card(
        color: Colors.white,
        child: Padding(
          padding: const EdgeInsets.symmetric(
            horizontal: 16,
            vertical: 8,
          ),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Icon(
                Icons.search_off_outlined,
                size: 66,
                color: Color(0xff0D7A8F),
              ),
              Text(
                "No mathcing employees found",
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.w500,
                ),
              ),
              SizedBox(height: 16),
              ClearFiltersButton(
                onPressed: onPressed,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
