import 'package:assignment_d02/components/commit_button.dart';
import 'package:assignment_d02/components/critical_directives_queue.dart';
import 'package:assignment_d02/components/filter_section.dart';
import 'package:assignment_d02/components/profile_card.dart';
import 'package:assignment_d02/components/progress_section.dart';
import 'package:assignment_d02/components/queue_item.dart';
import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  //--------------------CheckList---------------------------
  final List<QueueItem> _queueItems = [
    QueueItem(
      icon: Icons.storage_rounded,
      title: "Database Consolidation",
      subtitle: "Optimization in progress",
    ),
    QueueItem(
      icon: Icons.account_tree,
      title: "Network Link Stability",
      subtitle: "Monnitoring connections",
    ),
    QueueItem(
      icon: Icons.security,
      title: "Firewall Rules Update",
      subtitle: "Applying new policies",
    ),
    QueueItem(
      icon: Icons.cloud_sync,
      title: "Cloud State Synchronization",
      subtitle: "Aligning remote nodes",
    ),
    QueueItem(
      icon: Icons.memory,
      title: "Memory Allocation Check",
      subtitle: "Freeing system resources",
    ),
    QueueItem(
      icon: Icons.admin_panel_settings,
      title: "OSI Layer Validation",
      subtitle: "Verifying transport protocols",
    ),
    QueueItem(
      icon: Icons.analytics,
      title: "Telemetry Data Export",
      subtitle: "Compiling usage metrics",
    ),
    QueueItem(
      icon: Icons.bug_report,
      title: "Automated Vulnerability Scan",
      subtitle: "Testing endpoint security",
    ),
    QueueItem(
      icon: Icons.dns,
      title: "DNS Routing Update",
      subtitle: "Flushing local cache",
    ),
  ];
  final Set<int> _completedTaskIndexes = {};
  int get _completedTaskCount {
    return _completedTaskIndexes.length;
  }

  int get _progressValue {
    return ((_completedTaskCount / _queueItems.length) * 100).round();
  }

  // bool get _areAllTasksCompleted {
  //   return _completedTaskCount == _queueItems.length;
  // }

  void _toggleTask(int i, bool? value) {
    setState(() {
      if (_completedTaskIndexes.contains(i)) {
        _completedTaskIndexes.remove(i);
      } else {
        _completedTaskIndexes.add(i);
      }
    });
  }

  //--------------------TextField---------------------------
  final TextEditingController _engineerController = TextEditingController();
  String _engineerPreview = "SENIOR ENGINEER";

  void _updateEngineerNamePreview() {
    final String typedName = _engineerController.text.trim();
    setState(() {
      if (typedName.isEmpty) {
        _engineerPreview = "SENIOR ENGINEER";
      } else {
        _engineerPreview = typedName;
      }
    });
  }

  @override
  void initState() {
    _engineerController.addListener(_updateEngineerNamePreview);
    super.initState();
  }

  @override
  void dispose() {
    _engineerController.removeListener(_updateEngineerNamePreview);
    super.dispose();
  }

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
            style: TextStyle(fontSize: 24, fontWeight: FontWeight.w600),
          ),
        ),
      ),
      body: Column(
        children: [
          Expanded(
            child: SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  children: [
                    ProfileCard(
                      controller: _engineerController,
                      engineerName: _engineerPreview,
                    ),
                    const SizedBox(height: 25),
                    FilterSection(),
                    ProgressSection(
                      totalQueueitems: _queueItems.length,
                      completedItems: _completedTaskCount,
                      progressValue: _progressValue,
                    ),
                    const SizedBox(height: 25),
                    CriticalDirectivesQueue(
                      queueItems: _queueItems,
                      completedtasks: _completedTaskIndexes,
                      onTaskChanged: _toggleTask,
                    ),
                  ],
                ),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: CommitButton(),
          ),
        ],
      ),
    );
  }
}
