# PropDeal

A property website with buyer and seller accounts, rent and sale listings, meeting requests, a limited-time deal countdown and a MySQL database file. Plain HTML, CSS and JavaScript. No install and no server needed.

## Files (keep all 7 in one folder)

| File | What it is |
|---|---|
| `login.html` | Start here. Sign in or create an account, then you are sent to the right page for your role. |
| `buyer.html` | Buyer home: photo slideshow, red offers line, deal countdown, filters, listings, "My meetings". Click a card to open the full property page. |
| `seller.html` | Seller home: add, delete and filter your listings, answer meeting requests. |
| `app.js` | All the logic: accounts, listings, filters, property page, meetings, validation, deals, particles. |
| `style.css` | All the styling. |
| `schema.sql` | MySQL / MariaDB database: structure plus all sample data in one file. |
| `README.md` | This file. |

The full property page (gallery, price, description, features, meeting form) opens inside `buyer.html` and `seller.html` when you click a card. It has no file of its own.

## Run it

Open `login.html` in a browser. Use the "Use Seller / Buyer / Admin" buttons, or create your own account with "Create account".

| Role | Email (username) | Password |
|---|---|---|
| Seller | seller@example.com | Seller@1234 |
| Buyer | buyer@example.com | Buyer@1234 |
| Admin | admin@example.com | Admin@1234 |

To set your own fixed accounts, edit the `USERS` list at the top of `app.js`.

## GitHub Pages

Upload the 7 files, then Settings > Pages > Branch `main`. Your site opens at `https://<user>.github.io/<repo>/login.html`.
To make it the main address instead, rename `login.html` to `index.html` and change `LOGIN_PAGE` near the top of the accounts section in `app.js` to `'index.html'`.
If an older version of this project is already in your repo, delete the old `index.html` and `property.html` from it.

## Features

- 28 sample listings (houses, apartments, shops, plots) with 3 to 4 photos each. Filters: type, For Sale, For Rent, Deals, favourites.
- Sellers list for sale or rent, mark the price negotiable or fixed, set a minimum rental period and upload up to 4 photos.
- Buyers ask for a meeting. For rentals they also say how many months they need. The seller accepts or declines and the buyer sees the status.
- Buyer home: slideshow (new photo every 3 seconds), red scrolling offers line at the top, and a countdown to the end of a 10% deal on 6 selected properties. A new set of deals starts when it reaches zero. Change `OFFER` in `app.js` to adjust it. Sellers do not see the discount.
- Forms are validated: email needs `@`, password 6+ characters (sign-up also needs upper case, lower case, a number and a special character), age and numeric fields accept digits only, required fields cannot be empty.

## Database

Import `schema.sql` with phpMyAdmin (Import tab) or `mysql -u root -p < schema.sql`. It creates the `propdeal` database with these tables: `users`, `properties`, `property_images`, `property_features`, `favorites`, `meetings`, `deals`, `deal_properties`, `announcements` and the view `v_property_cards`. It also loads 3 demo accounts (bcrypt-hashed passwords), 28 listings, 100 photos, 122 features and sample favourites, meetings, a deal and the red-line messages. Importing again resets the PropDeal tables.

The website itself saves data in the browser (localStorage), so accounts, listings and meetings stay on that browser only. It does not read from MySQL until a backend such as Node.js is connected to this database. Passwords in the browser version are stored as plain text, so it is for demonstration only.
