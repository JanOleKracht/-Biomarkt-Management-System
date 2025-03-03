
# ProNatur Biomarkt Management System
## Overview

ProNatur Biomarkt GmbH is a product management system designed to help manage inventory, store product details, and facilitate CRUD (Create, Read, Update, Delete) operations on products.

This project is on of my first learning projects where I practice **Object-Oriented Programming (OOP)** in C# and integrate an **SQL database**. My goal is to understand how to structure a C# application, interact with a database, and handle common challenges in software development. 

## Features

•	**Add new products** with details such as name, brand, category, price, and quantity.

•	**Edit existing** products and update their details.

•	**Delete products** from the inventory.

•	**Filter products** by name, brand, or category.

•	**Load all products** into a DataGridView for easy viewing.

## Technologies Used

•	**C#** (Windows Forms Application)

•	**SQL** Server (LocalDB)

•	**Dapper** (for database interaction)

•	**Windows Forms** (WinForms UI Framework)


## Project Structure

![image](https://github.com/user-attachments/assets/5723443a-fd2c-4e80-b5f4-525bebe8311a)



## Setup & Installation
### Prerequisites

Visual Studio (recommended)

SQL Server LocalDB

.NET Framework (4.7 or later)


## Steps

1. Clone the repository:
git clone https://github.com/JanOleKracht/-Biomarkt-Management-System.git

2. Open the solution in Visual Studio.

3. Ensure the database file ProNatur-BiomarktTable.mdf is in the correct location.

4. Run the application in Visual Studio.

## How to Use

**1. Add a product:**
  - Enter product details in the form fields.
  - Click Save to store the product in the database.

**2. Edit a product:**
- Select a product from the list.
- Modify the details and click Edit.

**3. Delete a product:**
- Select a product from the list.
- Click Delete and confirm the action.

**4. Filter products:**
- Choose a filter type (Name, Brand, Category).
- Select a value and click Filter.

## SQL Basics

This project uses SQL Server LocalDB for storing product information. Here are some basic SQL commands I used with example "Values":

![image](https://github.com/user-attachments/assets/bb3a5b46-18f0-4ac8-ba19-054a8d7808ad)

## Common SQL Mistakes and How to Fix Them

**1. Database connection issues:**
- Ensure that the ```.mdf``` file is correctly attached in SQL Server.
- Check the connection string in ```DatabaseHelper.cs.```

**2. SQL syntax errors:**
- Double-check your queries for missing commas, incorrect keywords, or misplaced conditions.

**3. Primary key conflicts:**
- If an error says ```Primary key constraint violated```, make sure IDs are unique.

## Contributing

This is a personal learning project, so contributions are not expected. However, if you have any feedback or suggestions, feel free to reach out.

## License

This project is licensed under the MIT License. You are free to use, modify, and distribute this project as long as you include the license and give
credit to the original author.


## Developer

GitHub Username: JanOleKracht
