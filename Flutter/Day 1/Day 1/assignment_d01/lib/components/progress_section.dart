import 'package:flutter/material.dart';

class ProgressSection extends StatelessWidget {
  const ProgressSection({super.key});

  @override
  Widget build(BuildContext context) {
    return const Card(
      elevation: 8.0,
      color: Colors.white,
      child: Padding(
        padding: EdgeInsets.symmetric(vertical: 20, horizontal: 15),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  children: [
                    Text(
                      "14 / 20",
                      style: TextStyle(
                        fontWeight: FontWeight.w500,
                        fontSize: 50,
                      ),
                    ),
                    Icon(
                      Icons.arrow_upward_rounded,
                      size: 40,
                      color: Color(0xff45874B),
                    ),
                  ],
                ),
                Row(
                  children: [
                    Text(
                      "Tasks Optimized",
                      style: TextStyle(
                        fontWeight: FontWeight.w500,
                        fontSize: 20,
                      ),
                    ),
                    SizedBox(width: 10),
                    Icon(
                      size: 35,
                      Icons.check_circle,
                      color: Color(0xff45874B),
                    ),
                  ],
                ),
              ],
            ),
            Stack(
              alignment: Alignment.center,
              children: [
                SizedBox(
                  width: 80,
                  height: 80,
                  child: CircularProgressIndicator(
                    value: 0.7,
                    strokeWidth: 9,
                    backgroundColor: Color(0xffCACEDA),
                    valueColor: AlwaysStoppedAnimation<Color>(
                      Color(0xff566B80),
                    ),
                    strokeCap: StrokeCap.round,
                  ),
                ),
                Text(
                  "70%",
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.w600,
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
