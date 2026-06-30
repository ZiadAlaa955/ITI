void task1() {
  /**
   * ^2.4.5
   * major release: 2.0.0
   * minor release: 0.4.0
   * patch: 0.0.5
   * minimum: >= 2.4.5
   * maximum: 3.0.0
   * 
   * ^0.4.5
   * minimum: >= 0.4.5
   * maximum: 0.5.0 (pre)
   * Dart handles breaking changes differently before major version 1.0.0 => treat minor version as breaking changes
   * 
   * lock exact version => package_name: 2.3.2
   * explicit range => >=2.3.3 < 3.0.0
   */
}
