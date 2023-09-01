# MarthaLibraryManagement
This is a full-stack project built for Lenkie assessment

# Question
Martha owns a local library, her customers often complain about coming to the book store and not finding the books they came to borrow. To prevent this, customers currently call the library and ask if the books they are looking for are available. Typically, over the call:

The customer specifies the name of the book
Martha checks her library for the book
If it's available, the customer has the option to reserve it for the next 24 hours until they've come to the library to collect it.
If the book is reserved, another customer cannot reserve or borrow it.
If the book has been borrowed by another customer, Martha lets the enquiring customer know when the book would be returned to the library
Martha's library has recently gained massive popularity after a visit from a popular fiction novel writer. Her customer base has increased and continues to grow. She would like to focus on rennovating her library to accomodate more people. Managing and renting out books over the telephone is taking too much of her time and resources, she is looking for a way for customers to search her library, reserve and borrow books online. She wants her customers to be able to access her library with whatever device they choose (cellphone, laptop, desktop, etc.)

Martha would also like her users to be able to access her library via a web application. She wants her users to be able to search for books, reserve books, enquire about books with regards to whether or not they are currently reserved, borrowed or available.

In your implementation, take into account the following key details:

Authentication & Authorization: Since the application will most likely store customer data, some security constraints must be enforced on who has access to the data.
API Documentation: The application should run on any device with or without a web browser, documenting the API would be important as it would allow any frontend engineer to make the app available to customers using different devices.
Responsive Design: As much as possible, make the web application as responsive so that Martha's customers can access it from a wide range of devices.
Bonus:
For books that are reserved / currently borrowed out, customers should be able to request to be notified once the book is now available in the library. In this initial iteration, the notification could be persisted in some notifications table / storage at the time the book becomes available.

What Tools Can You Use?
Use this opportunity to showcase your understanding of software architecture using .NET Core/Node.JS for your backend and either Vue.JS / React.JS / AngularJS on the frontend

You may use whatever persistent storage you think is best.

Demonstrate your understanding of OAuth and how it can be used to secure APIs. You can use your own Identity Server or leverage an existing one.

Demonstrate your ability to make calls to API endpoints from your frontend application using best practices with regards to:

HTTP requests
Error Handling
Loading states
Authentication and Authorisation
