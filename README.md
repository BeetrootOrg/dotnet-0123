# Finance Management System

This is a simple finance management system, that allows you to easily manage your spendings and income.

## User Stories 

- As a user, I want to be able to create financial accounting;
- As a user, I want to be able to keep financial records;
- As a user, I wnat to be able to split financial accountings;
- As a user, I want to be able to see visualisation of spendings;
- As a user, I want to be able to see how many times I've changed accounting;


## Features

Application can handle following tasks:
- `new` - Creating new financial accounting;
- `set_value_init` - Setting initial capital;
- `add` - Adding money to this accounting;
- `subtract` - Subtract money from this accounting;
- `set_value` - Setting amount of money;

## Accounting Fields

Every your accounting have the following fields:
- `id` - The unique identifier of the accounting;
- `title` - Name of accounting;
- `value` - Amount of money;
- `iterations` - Number of all iterations that was done
- `created_at` - The date and time when accounting was created;

## Accounting Endpoints

The following endpoints are available for interacting with accountings:
- `GET /accounting/:id` - Retrieve accounting by id;
- `PATCH /accounting/:id/value` - Update value of an accounting;
- `PUT /accounting` - Create new accounting;

