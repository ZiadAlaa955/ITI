import 'package:flutter/material.dart';

class ProgressSection extends StatelessWidget {
  const ProgressSection({
    super.key,
    required this.totalQueueitems,
    required this.completedItems,
    required this.progressValue,
  });
  final int totalQueueitems;
  final int completedItems;
  final int progressValue;

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: 8.0,
      color: Colors.white,
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 15),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  children: [
                    Text(
                      "$completedItems / $totalQueueitems",
                      style: const TextStyle(
                        fontWeight: FontWeight.w500,
                        fontSize: 50,
                      ),
                    ),
                    const Icon(
                      Icons.arrow_upward_rounded,
                      size: 40,
                      color: Color(0xff45874B),
                    ),
                  ],
                ),
                const Row(
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
                    value: progressValue / 100,
                    strokeWidth: 9,
                    backgroundColor: const Color(0xffCACEDA),
                    valueColor: const AlwaysStoppedAnimation<Color>(
                      Color(0xff566B80),
                    ),
                    strokeCap: StrokeCap.round,
                  ),
                ),
                Text(
                  "$progressValue%",
                  style: const TextStyle(
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
