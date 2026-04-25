function showAddress(addressObj) {
  console.log(
    addressObj.buildingNumber +
      " " +
      addressObj.street +
      " st., " +
      addressObj.city +
      " city, registered in " +
      addressObj.date
  );
}

function inputData() {
  let street = prompt("Enter street name: ");
  let buildingNumber = prompt("Enter building number:");
  let city = prompt("Enter city name: ");

  let userInputs = {
    street: street,
    buildingNumber: buildingNumber,
    city: city,
    date: new Date().toLocaleDateString(),
  };

  showAddress(userInputs);
}

inputData();
