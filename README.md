# Bookstore
## How to run the system
1. Open a cmd inside the project folder with the `docker-compose.yml` file.
2. Ensure that docker desktop is open.
3. Run `docker compose up -d --build` <-- or any preferred variant
4. Access the API at `http://localhost:5000/swagger/index.html` or `http://localhost:5001/swagger/index.html`

## Design choices
### Databases
We chose MSSQL for the relational database, and decided to use Redis for the NoSQL database. We chose these two as it made sense for the way our data is structured with a fixed structure.

### Data
We used MSSQL for `Books`, `Customers`, and `Orders` as those models would have more than two columns, and would also have the relation between each other. We then used Redis for `Authors` and `StockLevels` since those models would only contain an ID and some value; although, they will have relation to `Books` that could be handled through logic considering the benefits of using Redis in this case. We are caching all `GET` methods, whenever we try to call a `GET` method, we check the cache first and if it's not empty we will return the record, otherwise we will make a database call and store it in cache for use within 2 minutes as to not keep stale data.
