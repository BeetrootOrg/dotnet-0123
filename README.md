# Finance Management System

This is a simple finance management system, that allows you to easily manage your spendings and income.

## User Stories 

- As a user, I want to be able to create financial accounting;
- As a user, I want to be able to keep financial records;
- As a user, I wnat to be able to split financial accountings;
- As a user, I want to be able to see visualisation of spendings;
- As a user, I want to be able to delete financial accounting;


## Features

Application can handle following tasks:
- `new` - Creating new financial accounting;
- `set_value` - Setting initial capital;
- `add` - Adding money to this accounting;
- `subtract` - Subtract money from this accounting;
- `delete` - Removing accounting;

## Accounting Fields

Every your accounting have the following fields:
- `id` - The unique identifier of the accounting;
- `value` - Amount of money;
- `iterations` - List of all iterations that was done
- `created_at` - The date and time when accounting was created;
- `updated_at` - The date and time when accounting was updated;

## Iteration Fields

Every iteration of adding or subtracting have the following fields:
- `id` - The unique identifier for the iteration;
- `name` - The name of iteration;
- `type` - Type of transaction;
- `sum` - Amount of money;
- `created_at` - The date and time when iteration was done;
- `sign` - Minus or plus depending on what operation was done;
- `account_id` - The unique identifier of the accounting;

## Accounting Endpoints

The following endpoints are available for interacting with accountings:
- `GET /accounting/:id` - Retrieve accounting by id;
- `PATCH /accounting/:id/value` - Update value of an accounting;
- `PUT /accounting` - Create new accounting;

