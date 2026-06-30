import 'package:assignment_d04/components/filters/filter_item.dart';
import 'package:flutter/material.dart';

class FilterSection extends StatelessWidget {
  const FilterSection({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      padding: EdgeInsets.only(bottom: 25),
      child: const Row(
        children: [
          FilterItem(
            text: 'All Tasks',
            backgroundColor: Color(0xffD8DFE9),
            borderColor: Color(0xff253B53),
            textColor: Color(0xff253B53),
          ),
          SizedBox(width: 12),
          FilterItem(
            text: 'In progress',
            backgroundColor: Color(0xffFEF2E2),
            borderColor: Color(0xff805B24),
            textColor: Color(0xff805B24),
          ),
          SizedBox(width: 12),
          FilterItem(
            text: 'Completed',
            backgroundColor: Color(0xffE5F3E3),
            borderColor: Color(0xff37613D),
            textColor: Color(0xff37613D),
          ),
          SizedBox(width: 12),
          FilterItem(
            text: 'Archived',
            backgroundColor: Color(0xffE2D4EE),
            borderColor: Color(0xff4F335B),
            textColor: Color(0xff4F335B),
          ),
        ],
      ),
    );
  }
}
