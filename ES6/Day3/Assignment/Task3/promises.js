const tableContainer = document.createElement("div");
document.body.appendChild(tableContainer);

fetch("https://jsonplaceholder.typicode.com/users")
  .then((response) => {
    if (response.ok) {
      return response.json();
    } else {
      throw "Error, response not OK";
    }
  })
  .then((users) => {
    tableContainer.innerHTML = "";
    generateTable(users);
  })
  .catch((error) => {
    tableContainer.innerHTML = `<p style="color:red">Error: ${error.message}</p>`;
  });

function generateTable(data) {
  // A. Create Table Element
  const table = document.createElement("table");

  // B. Create Table Head (thead)
  const thead = document.createElement("thead");
  const headerRow = document.createElement("tr");

  // Define our columns
  const headers = ["ID", "Name", "Email", "City", "Company"];

  headers.forEach((headerText) => {
    const th = document.createElement("th");
    th.textContent = headerText;
    headerRow.appendChild(th);
  });

  thead.appendChild(headerRow);
  table.appendChild(thead);

  // C. Create Table Body (tbody)
  const tbody = document.createElement("tbody");

  data.forEach((user) => {
    const row = document.createElement("tr");

    // Create cells for specific data points
    // Helper to create a cell quickly
    const createCell = (text) => {
      const td = document.createElement("td");
      td.textContent = text;
      row.appendChild(td);
    };

    createCell(user.id);
    createCell(user.name);
    createCell(user.email);
    createCell(user.address.city); // Nested property
    createCell(user.company.name); // Nested property

    tbody.appendChild(row);
  });

  table.appendChild(tbody);

  // D. Append the finished table to the page
  tableContainer.appendChild(table);
}
