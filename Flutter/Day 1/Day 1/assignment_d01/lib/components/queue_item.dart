import 'package:flutter/material.dart';

class QueueItem extends StatelessWidget {
  const QueueItem({
    super.key,
    required this.icon,
    required this.title,
    required this.subtitle,
  });
  final IconData icon;
  final String title;
  final String subtitle;

  @override
  Widget build(BuildContext context) {
    return Row(
      // mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Padding(
          padding: EdgeInsets.only(left: 10, right: 20),
          child: Icon(
            icon,
            size: 35,
          ),
        ),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              title,
              style: TextStyle(
                fontSize: 18,
              ),
            ),
            Text(
              subtitle,
              style: TextStyle(
                fontSize: 15,
              ),
            ),
          ],
        ),
        Spacer(),
        Padding(
          padding: EdgeInsets.only(right: 8),
          child: Icon(
            Icons.arrow_forward_ios_rounded,
            size: 25,
          ),
        ),
      ],
    );
  }
}
