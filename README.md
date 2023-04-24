# Task Management System

This is a simple task management system that allows you to create tasks, assign them to users, and track their statuses.

## Task Statuses

Tasks can be in one of the following statuses:
- `new` - The task has been created but not yet assigned to a user;
- `assigned` - The task has been assigned to a user;
- `in_progress` - The task is being worked on by the assigned user;
- `complete` - The task has been completed;
- `cancelled` - The task has been cancelled.

## Task Fields

Tasks have the following fields:
- `id` - The unique identifier for the task;
- `title` - The title of the task;
- `description` - The description of the task;
- `status` - The status of the task;
- `created_at` - The date and time the task was created;
- `updated_at` - The date and time the task was last updated;
- `assignee_email` - The email address of the user assigned to the task.

## Task Endpoints

The following endpoints are available for interacting with tasks:
- `GET /tasks/:id` - Retrieve a task by its ID;
- `PUT /tasks` - Create a new task;
- `POST /tasks/:id` - Assign a task to a user;
- `PATCH /tasks/:id/status` - Update the status of a task.

## Task API Limitations

The following limitations apply to the task API:
- Tasks status can only be updated in the following order: `new` -> `assigned` -> `in_progress` -> `complete`;
- Tasks transition from `new` to `in_progress` must be done by the user assigned to the task;
- Task can be cancelled at any time;
- Tasks status can only be updated when task is assigned to a user.
