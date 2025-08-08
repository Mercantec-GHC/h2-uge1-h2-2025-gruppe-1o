🌌 Features
Pulls daily APOD image from NASA.

Generates a 4-option multiple choice quiz.

Shows correct answer and full explanation.

🛠 Structure
Pages/NasaQuiz.razor – UI + quiz logic

Services/APIService.cs – Fetches NASA API data

Models/ApodData.cs – Data model

⚠ API Key Note
The included API key is public and rate-limited. For production, secure it with appsettings.json, user secrets, or Azure Key Vault.
