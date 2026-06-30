({double lat, double lon}) processCoordinates() {
  return (lat: 29.800, lon: 30.8212);
}

void task1() {
  final (:lat, :lon) = processCoordinates();
  print(lat);
  print(lon);
}
