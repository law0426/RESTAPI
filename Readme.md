# To-do REST API

This is a Project made to manage Todo items. Built on Aspnetcore.

We're building the data on a singleton, loading it to memory, meaning data isn't persistent between runs.
Shutting down or restarting will clear the data.

## Running the API

Change to project directory:

```bash
cd WebApi
```
From the project directory, run:

```bash
dotnet run
```

## API

### Todo item

TODO: the below example is not true. Fix.

```json
{
	"title": "Buy milk",
	"text": "Use the supermarket near home",
	"deadline": "2026-12-31T17:00:00+00:00",
	"id": "00000000-0000-0000-0000-000000000000",
	"created": "2026-08-20T15:35:44.339Z",
	"lastModified": "2026-08-20T15:35:44.339Z"
}
```

### Request body

TODO: UPDATE:

The `POST` and `PUT` endpoints accept the following JSON body:

```json
{
	"title": "Buy milk",
	"text": "Use the supermarket near home",
	"deadline": "2026-12-31T17:00:00+00:00"
}
```

- `title` is required and cannot be blank.
- `text` is optional.
- `deadline` is optional.

## Endpoints

TODO: UPDATE

| Method   | Route                    | Description           | Success response |
| -------- | ------------------------ | ----------------------| ---------------- |
| `POST`   | `/api/todo`              | Create a todo item    | `201 Created`    |
| `GET`    | `/api/todo`              | Return all todo items | `200 OK`         |
| `GET`    | `/api/todo/{id}`         | Return one todo item  | `200 OK`         |
| `PATCH`  | `/api/todo/complete{id}` | todo completion = true| `204 No Content` |
| `DELETE` | `/api/todo/{id}`         | Delete a todo item    | `204 No Content` |

The API returns:

- `400 Bad Request` when the title is missing or blank.
- `404 Not Found` when the requested ID does not exist.
- `201 Created` after successfully creating an item.
- `204 No Content` after successfully deleting or patching an item.


