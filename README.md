# Card Validation Application

## Overview
This project is a Card Validation Application designed to validate card information, check PIN codes, and provide various banking features such as balance viewing, money withdrawal, transaction history, deposit, PIN change, and currency conversion. It logs transactions to a JSON file for record-keeping.

## Features
- **Card Information Validation:** Validates card numbers and expiration dates.
- **PIN Code Check:** Allows users to validate their PIN codes.
- **Transaction Management:** Users can view recent transactions, withdraw money, deposit funds, and change their PIN.
- **Currency Conversion:** Provides options for currency conversion.
- **Error Handling:** Utilizes `try-catch` methods to manage errors gracefully.

## Project Structure
The project includes the following files:

- **CardApplication.csproj**: Project file for the Card Validation application.
- **CardData.json**: JSON file used for storing card and transaction data.
- **CardValidator.cs**: Contains logic for validating card numbers and expiration dates.
- **Program.cs**: Main entry point of the application, where the program flow is defined.
- **Transactions.cs**: Manages transaction details and history.
- **UserData.cs**: Handles user login processes and validation logic.
- **UserMenu.cs**: Displays the user menu with available actions.
- **.gitignore**: Specifies files and directories to ignore in the repository.
