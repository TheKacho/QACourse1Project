# QA-Knowledge-Check-1
Test Plan for the Shopping Cart feature for eBay

## | Description |
eBay has a newly implemented shopping cart that improves customer's shopping business. This new feature requires testing that covers the functions of adding/removing features work. They also have implemented a shopping cart icon that should show how many items are currently on hold before processed to checkout.

## | Website |
The website I have chosen for this www.ebay.com .

------
# QA-Knowledge Check-2
Test Plan Execution for the Shopping Cart Feature with Bug Reports

## | Preconditions |
- desktop browser (Windows 10)
- test device (HP ProBook with Intel Core i5 processor)
- Browser used: Firefox 106.0.5 64-Bit

## | Bug Report |
- Item limit that was capped at 5 can go over that limit without giving the error to the user

## | Recreating the bug |
- Go to ebay.com
- Select item that has a specific item cap
- Add the item up to max cap to cart
- On the cart checkout page, increase the item quanity 

- Expected: The item quantity cap cannot go past cap limit in the cart.
- Actual: Item limit has been surpassed without any warning in the cart.


------
 
 ## | Test Cases |
 
|Case TSC1| Add single product to cart 


| Steps |
- User selects the product
- User then clicks "Add to cart" button to add the product to cart


| Verify |
- verify that the cart page shows the necessary links and information prior to proceeding 
- the product should be successfully added to the cart in the cart icon as the number 1 should be displayed


| Result |
- item is in the cart, "1" is displayed on the cart icon

------
|Case TSC2| Multiple products in cart 

| Steps |
- User selects product(s) 
- click "add to cart" for item 1 
- choose a second item and click "add to cart"

| Verify |
- verify that the correct page shown with necessary links and informatnon before proceeeding
- verify that both items are successfully added to cart
- verify that the cart icon with the number 2 is displayed


| Result |
- the shopping cart should have both products and the cart icon displays a 2


------
|Case TSC3| Edit item quantity from the cart

| Steps |
- user selects product; click "add to cart" for item 1; 
- click 'add to cart' for item 2; edit quantity of item number with valid or invalid quantities (negative, 0, with spaces)

| Verify |
- verify that the cart page displays with all necessary links and info
- verify that the product should be added to cart successfully
- verify the quantity of items should br editable if user inputs an integer value; 
- if invalid, then a warning message should display to user


| Result |
- User is shown a warning message


------
|Case TSC4| Quantity boundaries while editing in cart 

| Steps |
- select product
- click 'add to cart' for chosen product 
- edit quantity of item with a value greater than 5 and click checkout 

| Verify |
- verify that the following page shown with vital links and information 
- products should be successfully added to cart
- check if item quantity number is higher than 5 then checkout is not allowed


| Result |
- warning error message is displayed to user

------

|Case TSC5| Removing product from the cart|

| Steps |
- select product 
- click add to cart
- click cart icon
- then click on the remove product icon from the cart

| Verify |
- cart icon should show 1 item; product on cart should be displayed
- when product on cart is removed, then the cart should be empty and the cart icon shows 0 items
- Result: cart has no items and its icon displays "0"


| Result |
-  Product is removed from cart

------
|Case TSC6| Removing multiple items in cart

| Steps |
- select product(s); select add to cart for item 1; 
- select add to cart for item 2; 
- select the remove item from cart to remove any items from the cart 

| Verify |
- check to see if the first item is added to cart, as the cart icon should have a 1 besides it
- if the second item is added to cart, check to see if the cart icon has both items and the cart icon has a 2 besides it 
- when removing one item from the cart, the cart should only show one item on the icon 

| Result |
- the cart has one item and the icon has "1" 

------
|Case TSC7| Guest checkout from shopping cart

| Steps |
-  go to web app page, but do not sign in
-  select product, click "add to cart" and then "proceed to purchase"
-  proceed to checkout page with payment/shipping options

| Verify |
-  check that the page is launched while the page says "Hello, Guest" on top of the page
-  check that the following pdp page shows the payment and shipping options to the user
-  the page then should show the user the option to sign in or continue as guest 
-  the user should then successfully go to the checkout page with the product
 
| Result |
-   user goes to checkout as a guest

------
|Case TSC8| Checkout from shopping cart with registered account

| Steps |
- go to eBay and sign in with registered account
- select product and click "add to cart" and then "proceed to checkout"
- proceed to checkout page with payment/shipping options


| Verify |
- check that the page is fully launched and it should display "Hello, USERNAME" on the top of the page
- check that the pdp page shows payment/shipping options to the user
- user should then successfully go to the checkout page with product

| Result |
-  User proceeds to checkout with an account


------

|Case TSC9| - applying one time discount promo code

| Steps |
- select product and add it to cart
- and use corresponding discount promo code in specified field while in the checkout

| Verify |
- check to see if the promo applied should deduct the product price correctly

- Result: Promo is applied to the product price

------
|Case TSC10| - duplicate discount promo codes

|Steps|
- select product and add to cart
- apply the same discount promo code (used from the same product earlier) while in checkout


|Verify|
- check to see if an error message pops up that states "This promo has already been used."

| Result |
- A pop-up message displays to user saying "This Promo has already been used." 