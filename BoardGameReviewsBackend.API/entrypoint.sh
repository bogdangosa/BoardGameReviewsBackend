#!/bin/bash
set -e

echo "Running EF Core migrations..."
dotnet ef database update --project ../BoardGameReviewsBackend.Migrations --startup-project . --context ApplicationDbContext

echo "Starting application..."
exec dotnet BoardGameReviewsBackend.API.dll
