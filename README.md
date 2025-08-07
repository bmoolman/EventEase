# EventEase - Event Management Application

## Overview
EventEase is a Blazor-based web application that allows users to create and manage events. The application provides a simple and intuitive interface for tracking event details and attendance status with client-side data persistence.

## Features
- Create, view, update, and delete events
- Track event details including:
  - Name, date, and location
  - Organizer information (name and email)
  - Attendance status
- Persistent storage using browser's localStorage
- Responsive design with Bootstrap CSS

## Technology Stack
- .NET 9 with Blazor Server
- JavaScript interop for LocalStorage integration
- Bootstrap for responsive UI components

## Architecture
- **Components**:
  - EventCard: Displays and manages individual events
  - Pages: Home and Events management
  - Layout: Consistent UI structure with navigation
- **Services**:
  - EventService: Core event management functionality
  - LocalStorageService: Client-side data persistence
- **Models**:
  - EventModel: Data structure with validation

## Getting Started
1. Clone the repository
2. Run `dotnet restore`
3. Run `dotnet run`
4. Navigate to the provided URL in your browser

## Data Persistence
All event data is stored in the browser's localStorage, allowing users to:
- Maintain data between sessions
- Use the application offline after initial load
- Avoid server-side storage requirements

## Data Flow

1. **User Interface Layer**
   - `Home.razor`: Application entry point with navigation
   - `Events.razor`: Main event management interface
   - `EventCard.razor`: Individual event display and edit component

2. **Service Layer**
   - `EventService.cs`: Handles in-memory event operations
   - `LocalStorageService.cs`: Manages browser storage operations

3. **Data Layer**
   - `EventModel.cs`: Data structure with validation rules
   - `localStorageInterop.js`: JavaScript bridge for browser storage

4. **Application Flow**
   - User creates/edits events via the Events page
   - EventService processes the changes in memory
   - LocalStorageService persists changes to the browser
   - On page reload, data is retrieved from localStorage

## Technical Implementation

- Components use Blazor's component model with parameters and callbacks
- Data binding connects UI elements to C# properties
- Services are injected via dependency injection configured in Program.cs
- JavaScript interop enables browser localStorage access from C#

## License
MIT License - free to use with no restrictions.




