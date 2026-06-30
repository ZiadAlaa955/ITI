import 'package:assignment_d01/components/queue_item.dart';
import 'package:flutter/material.dart';

class CriticalDirectivesQueue extends StatelessWidget {
  const CriticalDirectivesQueue({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: const Card(
        elevation: 8.0,
        color: Colors.white,
        child: Padding(
          padding: EdgeInsets.all(10),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Critical Directives Queue",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 25,
                ),
              ),
              SizedBox(height: 10),
              QueueItem(
                icon: Icons.storage_rounded,
                title: "Database Consolidation",
                subtitle: "Optimization in progress",
              ),
              Divider(
                indent: 20,
                endIndent: 20,
              ),
              QueueItem(
                icon: Icons.account_tree,
                title: "Network Link Stability",
                subtitle: "Monnitoring connections",
              ),
              Divider(
                indent: 20,
                endIndent: 20,
              ),
              QueueItem(
                icon: Icons.security,
                title: "Firewall Rules Update",
                subtitle: "Applying new policies",
              ),
            ],
          ),
        ),
      ),
    );
  }
}
