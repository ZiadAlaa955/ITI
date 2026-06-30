import 'package:assignment_d05/features/dashboard/presentation/widgets/queue_item.dart';
import 'package:flutter/material.dart';

class CriticalDirectivesQueue extends StatelessWidget {
  const CriticalDirectivesQueue({
    super.key,
    required this.queueItems,
    required this.completedtasks,
    required this.onTaskChanged,
  });

  final List<QueueItem> queueItems;
  final Set<int> completedtasks;
  final void Function(int i, bool? value) onTaskChanged;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Card(
        elevation: 8.0,
        color: Colors.white,
        child: Padding(
          padding: const  EdgeInsets.all(10),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              for (int i = 0; i < queueItems.length; i++) ...[
                CheckboxListTile(
                  contentPadding: EdgeInsets.zero,
                  value: completedtasks.contains(i),
                  onChanged: (value) {
                    onTaskChanged(i, value);
                  },
                  title: queueItems[i],
                  controlAffinity: ListTileControlAffinity.leading,
                ),
              ],
            ],
          ),
        ),
      ),
    );
  }
}
