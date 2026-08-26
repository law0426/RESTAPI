# To-do REST API

A small ASP.NET Core REST API for managing a list of todo items.

This is a demonstration API with in-memory data storage. Data is shared while the application is running and is lost when the application stops or restarts. Until the SQL database compatability is implemented.

## Running the API

From the project directory, run:

```bash
dotnet run
```

## API

### Todo item

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

| Method   | Route            | Description           | Success response |
| -------- | ---------------- | --------------------- | ---------------- |
| `POST`   | `/api/todo`      | Create a todo item    | `201 Created`    |
| `GET`    | `/api/todo`      | Return all todo items | `200 OK`         |
| `GET`    | `/api/todo/{id}` | Return one todo item  | `200 OK`         |
| `PUT`    | `/api/todo/{id}` | Replace a todo item   | `200 OK`         |
| `DELETE` | `/api/todo/{id}` | Delete a todo item    | `204 No Content` |

The API returns:

- `400 Bad Request` when the title is missing or blank.
- `404 Not Found` when the requested ID does not exist.
- `201 Created` after successfully creating an item.
- `204 No Content` after successfully deleting an item.
