function vehicle(speed, color) {
  if (typeof speed != "number") {
    throw "speed should be number type";
  } else if (typeof color != "string") {
    throw "color should be string type";
  } else {
    Object.defineProperties(this, {
      speed: {
        value: speed,
      },
      color: {
        value: color,
      },
    });
  }
}

vehicle.prototype.turnLeft = function () {
  return "Turning left";
};
vehicle.prototype.turnRight = function () {
  return "Turning right";
};
vehicle.prototype.start = function () {
  return "start";
};
vehicle.prototype.stop = function () {
  return "stop";
};
vehicle.prototype.GoBackward = function (speed, accel) {
  return "Go backward with speed: " + (speed - accel);
};
vehicle.prototype.GoForward = function (speed, accel) {
  return "Go forward with speed: " + (speed + accel);
};
vehicle.prototype.toString = function () {
  return "Speed: " + this.speed + ", Color: " + this.color;
};
vehicle.prototype.valueOf = function () {
  return this.speed;
};

/////////////////////////////////////////
function Bicycle(speed, color) {
  vehicle.call(this, speed, color);
}

Bicycle.prototype = Object.create(vehicle.prototype);
Bicycle.prototype.constructor = Bicycle;

Bicycle.prototype.ringBell = function () {
  return "Bill is ringing";
};

///////////////////////////////////////////
function motorVehicle(speed, color, sizeOfEngine, licencePlate) {
  vehicle.call(this, speed, color);
  if (typeof sizeOfEngine != "number") {
    throw "size of engine should be a number";
  } else if (typeof licencePlate != "string") {
    throw "licence plate should be a string";
  } else {
    Object.defineProperties(this, {
      sizeOdEngine: {
        value: sizeOfEngine,
      },
      licencePlate: {
        value: licencePlate,
      },
    });
  }
}

motorVehicle.prototype = Object.create(vehicle.prototype);
motorVehicle.prototype.constructor = motorVehicle;

motorVehicle.prototype.getSizeOfEngine = function () {
  return this.sizeOfEngine;
};
motorVehicle.prototype.gerLicencePlate = function () {
  return this.licencePlate;
};

////////////////////////////////////////////
function dumpTruck(
  speed,
  color,
  sizeOfEngine,
  licencePlate,
  loadCapacity,
  numWheels,
  weight
) {
  motorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);

  if (typeof loadCapacity != "number") {
    throw "load capacity should be a number";
  } else if (typeof numWheels != "number") {
    throw "number of wheels should be a number";
  } else if (typeof weight != "number") {
    throw "truck wight should be a number";
  } else {
    Object.defineProperties(this, {
      loadCapacity: {
        value: loadCapacity,
      },
      numWheels: {
        value: numWheels,
      },
      weight: {
        value: weight,
      },
    });
  }
}
dumpTruck.prototype = Object.create(motorVehicle.prototype);
dumpTruck.prototype.constructor = dumpTruck;

dumpTruck.prototype.lowerLoad = function () {
  return "Lower Load";
};
dumpTruck.prototype.raiseLoad = function () {};

/////////////////////////////////////////////
function car(
  speed,
  color,
  sizeOfEngine,
  licencePlate,
  numOfDoors,
  numWheels,
  weight
) {
  motorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);
  if (typeof numOfDoors != "number") {
    throw "number of doors should be a number type";
  } else if (typeof numWheels != "number") {
    throw "number of wheels should be a number";
  } else if (typeof weight != "number") {
    throw "car wight should be a number";
  } else {
    Object.defineProperties(this, {
      numOfDoors: {
        value: numOfDoors,
      },
      numWheels: {
        value: numWheels,
      },
      weight: {
        value: weight,
      },
    });
  }
}

car.prototype = Object.create(motorVehicle.prototype);
car.prototype.constructor = car;

car.prototype.swaitchOnAirCon = function () {
  return "switch air conditioner on";
};
car.prototype.getNumOfDoors = function () {};

//////////////////Testing//////////////////////////
let vhecile1 = new vehicle(50, "Blue");
console.log(vhecile1.start());
console.log(vhecile1.GoForward(50, 50));

console.log("");
let bicycle1 = new Bicycle(50, "Red");
console.log(bicycle1.ringBell());
console.log(bicycle1.toString());

console.log("");
let motorVhecile1 = new motorVehicle(50, "Red", 200, "abc123");
console.log(motorVhecile1.gerLicencePlate());
console.log(motorVhecile1.valueOf());

console.log("");
let dumpTruck1 = new dumpTruck(50, "Green", 200, "xyz456", 300, 8, 500);
console.log(dumpTruck1.gerLicencePlate());
console.log(dumpTruck1.lowerLoad());

console.log("");
let car1 = new car(50, "Green", 200, "xyz456", 4, 8, 500);
console.log(car1.gerLicencePlate());
console.log(car1.swaitchOnAirCon());
