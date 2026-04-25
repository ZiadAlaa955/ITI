# Cinema Ticket Reservation System

A simple and efficient console-based cinema booking system built with **C++**.  
Users can browse movies, pick showtimes, choose seats, and complete reservations.  
Admins can manage movies and showtimes through a text-based interface.

---

## Software Engineering Model — Agile

- Rapid delivery of core features  
- Easy addition of new requirements  
- Frequent testing & early issue detection  
- Continuous stakeholder feedback  
- Iterative development with small sprints  

---

## Functional Requirements

### **User Features**
- Browse available movies  
- Select movie by date  
- Choose showtime  
- Select seats for a showtime  
- Cancel reservation before payment  
- Complete payment (console-simulated)  

### **System Features**
- Calculate ticket price automatically  
- Mark seats as occupied after successful payment  
- Provide multiple payment method options (simulated)  
- Display all reserved tickets for a user  

### **Admin Features**
- Add movies (title, duration, genre, rating, description)  
- Edit movie information  
- Delete movies  
- List all movies  
- Create showtimes (date & time)  
- Edit showtime details  
- Delete showtimes  

---

## Non-Functional Requirements

### **Performance**
- Main menu loads within **3 seconds**  
- Movie search responds within **2 seconds**  
- Payment simulation completes within **5 seconds**

### **Security**
- User information protected internally  
- No sensitive data stored in plain text  

### **Usability**
- Simple console UI with clear instructions  
- Easy menu-driven navigation  

### **Reliability**
- System prevents data loss during reservations  
- Handles failures gracefully  

### **Scalability**
- Supports large lists of movies, users, and showtimes  
- Efficient data structures for fast operations  

### **Portability**
- Runs on **Windows**, **Linux**, and **macOS**  

### **Maintainability**
- Code follows a clean, modular architecture  
- Easy to add new movies/showtimes  
- Simple file- or memory-based database  