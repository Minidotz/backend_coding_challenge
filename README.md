# Backend Coding Challenge
This is my take on the coding challenge for Mimo built on .NET 6 using a SQLite database.

## Important Notes
There were a few assumptions made for the challenge:
- Since chapters and lessons are displayed in an ordered state, the user cannot skip to the next unless they are revisiting a completed chapter/lesson.
- When the last lesson of a chapter is completed, the chapter is considered completed. Likewise, when the last lesson of a course is completed, the course is considered completed.
- The lesson progress API endpoint is called immediately after the user has completed the lesson.