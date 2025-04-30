# Community Cultural Festival Management System

This C# Windows Forms application was developed as a final project for the COP3366E course at Florida A&M University. It enables organizers to manage participant data and event logistics for a culturally inclusive community festival.

## 🎭 Project Theme

The application is inspired by **African and Caribbean traditions**, celebrating vibrant expressions such as drumming, dance, art, storytelling, and cuisine. Categories and design choices (including color themes) reflect symbolic cultural identity and pride. Historical influences like **Black Caesar** and the broader African diaspora subtly shape the event narrative.

## ✅ Features

- Register festival participants with name, cultural category, contact info, and fee
- Categories include: **Music, Dance, Visual Art, Culinary, Storytelling**
- Search participants by name
- Display all participants with formatted summaries
- Calculate total registration fees
- **Export to CSV** for external reporting
- Data validation and duplicate checks
- **Exception handling** for user input errors
- Color-themed, accessible **Windows Forms interface**
- Hover tooltips for user guidance
- Real-time field highlighting on successful input


## 🧱 Object-Oriented Design

The system is built around a modular, class-based structure:

### 🔹 Participant (Base Class)
Holds common fields: `Name`, `Category`, `ContactInfo`, `FeePaid`, and includes `IsValidRegistration()` for input validation.

### 🔹 ArtParticipant (Specialized Subclass)
Inherits from `Participant` and adds:
- `ArtMedium` (e.g., “Oil Painting”)
- `DisplayDimensions` (e.g., “4ft x 6ft`)
- Includes a method: `GetArtDescription()`

This demonstrates **inheritance** and flexibility for future expansion.

### 🔹 FestivalManager
Central logic controller that:
- Manages participants (`List<Participant>`)
- Adds/searches participants
- Provides statistics (fee total, export, etc.)
- Includes an **overloaded method**:  
  `CalculateTotalFees(decimal discountRate)` to apply promotional discounts

## ⚙️ Technologies

- C# (.NET Framework 4.7.2)
- Windows Forms (WinForms)
- Visual Studio 2022
- Git & GitHub

## 📁 Project Structure

/src/              - Source files  
├── Form1.cs       - Main Windows Form  
├── Participant.cs - Base class for participants  
├── ArtParticipant.cs - Subclass for visual art entries  
├── FestivalManager.cs - Logic and data management  

/docs/             - Documentation  
├── MANUAL.md      - User instructions  
└── screenshots/   - Screenshot assets  

README.md          - Project overview (this file)

## 📅 Status

✅ **Completed**  
📦 Submitted by: **May 1, 2025**  
👨🏾‍💻 Student: Michael Johnson

## 🙏🏾 Acknowledgments

Special thanks to **Florida A&M University** and **Professor Butler** for encouraging culturally responsive computing. 
---
