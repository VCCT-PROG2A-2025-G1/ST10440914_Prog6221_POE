# Cybersecurity Awareness Chatbot (WPF)

This is a Windows desktop application developed using C# and WPF as part of the Programming 2A POE (Part 3). The chatbot helps users learn about cybersecurity and interact with a friendly assistant through a graphical interface.

## Project Overview

The chatbot provides interactive assistance by responding to cybersecurity-related queries, managing tasks, offering a quiz feature, and maintaining an activity log of user interactions.

## Features

### Chatbot Interface
- Responds to keywords such as "phishing", "password", "2FA", "task", "quiz", "log"
- Greets the user with a randomly selected message
- Asks for the user's name and uses it in responses
- Displays user and bot messages in a structured format
- Supports Enter key for message submission

### Task Manager
- Allows users to add tasks with a title, description, and reminder date
- View all tasks, mark them as completed, or delete them
- Task actions are logged in the activity log

### Cybersecurity Quiz
- 20 multiple-choice questions covering key cybersecurity concepts
- Tracks score and gives final feedback
- Logs whether the quiz was completed or exited early

### Activity Log
- Tracks the last 10 user actions
- "Show More" button allows viewing the full log
- Entries include timestamps and descriptions

### GUI and Usability
- Built with WPF using XAML and C#
- Separate windows for tasks, quiz, and logs
- Consistent message formatting
- Error handling and message validation
