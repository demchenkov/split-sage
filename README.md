# SplitSageBot - A Telegram Bot for Shared Expense Management  

## Overview  

**SplitSageBot** is a Telegram-based application inspired by [Splitwise](https://www.splitwise.com/). It simplifies shared expense tracking, allowing users to manage balances and settle debts with their friends or groups—all directly within Telegram.  

The application leverages the **Telegram Bot API** as its primary user interface and is powered by a robust backend built with **C#**, **PostgreSQL**, and potentially **Marten** for event sourcing.  

## Features  

- [ ] **Expense Tracking**  
  Add and manage shared expenses between friends or groups.  

- [ ] **Group Management**  
  Create groups, add participants, and assign expenses to specific groups.  

- [ ] **Balances & Settlements**  
  View balances, track who owes whom, and record payments to settle debts.  

- [ ] **Notifications**  
  Automated updates and reminders sent via Telegram messages.  

- [ ] **Multi-Currency Support** *(Planned)*  
  Handle expenses in different currencies and calculate conversions.  

## Technology Stack  

- **Backend:** C# (.NET 9)
- **Database:** PostgreSQL (with optional Marten for event sourcing)  
- **User Interface:** Telegram Bot API  
- **Architecture:** CQRS (Command Query Responsibility Segregation) and potentially Mediator Pattern (via MediatR)  

## Getting Started  

### Prerequisites  

Before running the project, make sure you have the following installed:  

- [.NET SDK](https://dotnet.microsoft.com/download)  
- [PostgreSQL](https://www.postgresql.org/download/)  
- [Ngrok](https://ngrok.com/) (for local bot development with Telegram webhooks)  

### Setup  

1. **Clone the repository:**  
   ```bash
   git clone https://github.com/demchenkov/split-sage.git
   cd splitsagebot
   ```
2. **Configure the database:**  
   - Create a new PostgreSQL database.  
   - Open the `appsettings.json` file and update the `ConnectionStrings` section with your PostgreSQL connection details, for example:  
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=splitsage;Username=yourusername;Password=yourpassword"
     }
     ```  

3. **Register the bot with Telegram:**  
   - Open Telegram and start a chat with [BotFather](https://core.telegram.org/bots#botfather).  
   - Use the `/newbot` command to create a bot, following BotFather's instructions.  
   - Once created, copy the bot token provided by BotFather.  
   - Add the bot token to your environment variables or include it in the `appsettings.json` file as follows:  
     ```json
     "Telegram": {
       "BotToken": "your-bot-token-here"
     }
     ```  

4. **Run the application:**  
   - Restore dependencies and build the project:  
     ```bash
     dotnet restore
     dotnet build
     ```  
   - Start the application:  
     ```bash
     dotnet run
     ```  

5. **Set up webhooks for Telegram:**  
   - Download and run [Ngrok](https://ngrok.com/) to expose your local server:  
     ```bash
     ngrok http 5000
     ```  
   - Copy the Ngrok URL (e.g., `https://<your-ngrok-url>.ngrok.io`).  
   - Register the webhook with Telegram using the following command:  
     ```bash
     curl -F "url=https://<your-ngrok-url>/api/telegram/webhook" https://api.telegram.org/bot<your-bot-token>/setWebhook
     ```  

### Usage  

1. Open Telegram and start a chat with **SplitSageBot** by searching for it in the Telegram app.  
2. Use `/start` to initialize the bot and explore its features.  
3. Available commands include:  
   - `/addexpense` - Add a new expense with your friends or groups.  
   - `/viewbalances` - Check balances for groups or individuals.  
   - `/settleup` - Record payments to clear debts.  
