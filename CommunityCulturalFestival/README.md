# 📝 MANUAL.md — User Guide

This manual provides step-by-step instructions for using the **Community Cultural Festival Management System**, a C# Windows Forms application built to register and manage participants in a culturally responsive community event.

---

## 🚀 Getting Started

1. Open the solution in **Visual Studio 2022**
2. Build the solution:  
   `Build > Build Solution` or press `Ctrl + Shift + B`
3. Run the application:  
   `Debug > Start Without Debugging` or press `Ctrl + F5`
4. The main form will launch with the festival registration interface

📦 Ensure `.NET Framework 4.7.2` is installed.
---

## 🖱️ Feature Walkthrough

### 📝 Registering a Participant
- Fill out the **Name**, **Category**, and **Contact Info**
- Select a **category** (e.g., African Drumming, Culinary - Soul Food)
- Click **Register**
- A success message will appear, and the fields will highlight briefly

📸 Screenshot: ![Register Participant](./screenshots/register_participant.png)


---

### 🔍 Search Participants
- Enter a name into the search field
- Click **Search**
- Matching results will populate in the list

📸 Screenshot: ![Search Result](./screenshots/search_result.png)

---

### 📃 View All Participants
- Click the **View All** button to see everyone currently registered

📸 Screenshot: ![View All](./screenshots/view_all.png)

---

### 💰 View Total Fees
- Click the **Total Fees** button to calculate and display total revenue

---

### 💾 Export to CSV
- Click **Export to CSV** to save participant data
- Choose a location and save
- File includes headers and formatted rows

📸 Screenshot: ![Export CSV](./screenshots/export_csv.png)

---

## ♿ Accessibility Features

- 🟢 High-contrast color theme for readability
- 🟡 Tooltip hints on all buttons and fields
- 🔄 Keyboard accessible (tab navigation through all inputs)
- 🆎 Clear, legible font styles

---

## 🛠️ Known Limitations

- Specialized participants (e.g., ArtParticipant) are implemented in code only and not linked to the form inputs
- Currently supports one cultural category per participant

---

## 📦 Developer Notes

- Code organized into reusable methods and classes
- Demonstrates inheritance via `ArtParticipant.cs`
- Includes an overloaded method `CalculateTotalFees(decimal)` for discounts

---

## 🙏 Thank You

Thank you for reviewing this project! Built with pride, purpose, and cultural appreciation.