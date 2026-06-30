void executeDatabaseQuery() {
  print("Query Executed");
}

Function profileExecution(Function originalFunction) {
  void wrapper() {
    print("Timer Started");
    originalFunction();
    print("Timer Stopped");
  }

  return wrapper;
}

void task3() {
  executeDatabaseQuery();

  Function wrappedQuery = profileExecution(executeDatabaseQuery);

  wrappedQuery();
}
