# List meetups

GET /api/meetups

Returns meetups ordered by time, then ID.

## Expected successful response

200 OK

```json
[
  {
    "id": 1,
    "title": "C# Study Meetup",
    "description": "Practice C# together.",
    "place": "Campus",
    "time": "2026-10-25T14:00:00",
    "maxCapacity": 20
  }
]
```

The example is illustrative, not actual database data.
The time-zone convention still needs team agreement.

When there are no meetups, the expected response is:
200 OK with [].

## Implementation status

- Controller and response DTO implemented.
- Project builds successfully.
- Database-backed testing pending entity mapping and table creation.