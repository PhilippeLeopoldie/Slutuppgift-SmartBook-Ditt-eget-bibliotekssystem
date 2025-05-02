# Slutuppgift-SmartBook-Ditt-eget-bibliotekssystem

# 📚 SmartBook – Your Personal Library System

SmartBook is a console-based library management system built with C#. It allows users to register, search, borrow, and manage books, with support for saving and loading data from a JSON file.

---

## ✨ Features

- 📖 Seed a list of books
- ➕ Register a new book
- ❌ Remove a book by ISBN or title
- 🔍 Search for a book by title or author
- 📋 Display the full list of books (sorted by title)
- 📥 Borrow a book (if available)
- 💾 Save your library to a JSON file
- 📂 Load your library from a JSON file

Each book includes the following:
- Title
- Author
- ISBN
- Genre (chosen from an enum)
- Availability status (Available / Borrowed)

---

## ▶️ How to Run

1. **Clone or download the repository**  

2. **Build and run the application**

3. **Use the interactive menu in the console**

  ####  Menu:
1. Ceed list of books

2. Register a book

3. Remove a book by ISBN

4. Remove a book by title

5. Display the list of books

6. Search book by title or author

7. Borrow a book

8. Save library into different JSON files (the user choose a file name)

9. Load library from different JSON files

0. Exit



## Unit Tests

1. Should_Add_One_Book_In_The_List

2. Should_Add_Multiple_Books_In_The_List

3. Should_Not_Add_Book_With_Duplicate_ISBN

4. Should_Found_Book_By_Title

5. Should_Found_Book_By_Author

6. Should_Return_Book_When_SearchByISBN

7. Should_Return_Null_When_Search_With_WrongISBN

8. Should_Remove_Book_byISBN

9. Should_Return_Null_When_Wrong_ISBN

10. Should_Remove_Book_byTitle

11. Should_Return_Null_When_Wrong_Title

12. Should_Display_Genres

13. Should_Borrow_Book

14. Should_Return_Null_When_Book_Not_Available

15. Should_Save_LibraryToJson_And_CreatesValidJsonFile
