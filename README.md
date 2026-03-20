# MerchProo: Merchandise Production Management System with POS and Workflow Tracking 

SDG Goal 8: Decent Work and Economic Growth & SDG Goal 9: Industry, Innovation, and Infrastructure

**Problem Statement**

Small merchandise and apparel businesses often struggle with fragmented operations, relying on manual logs or disconnected spreadsheets. This leads to untracked order statuses, frequent errors in sales recording, and an inability to monitor production bottlenecks. MerchPro solves this by integrating Order Management, Workflow Tracking, and POS into a single secure platform, fostering digital transformation and operational efficiency for small-scale industries.

**Overview**

The project is designed to simulate an enterprise-level development environment. It is not merely a coding exercise but a rigorous demonstration of software engineering principles, requiring students to bridge the gap between high-level architectural design and low-level technical implementation. The final output must be a robust, persistent, and secure utility capable of managing complex data relationships and delivering actionable insights for social or environmental impact.

The system supports Sustainable Development Goal 8 (Decent Work and Economic Growth) by improving business efficiency, supporting small-scale merchandise operations, and enabling better job productivity through automation and organized workflows.

It promotes economic growth by

- Streamlining order and payment processes

- Improving production efficiency through workflow tracking

- Supporting business decision-making using sales reports

- Reducing manual errors and workload for employees

**System Architecture**

├── bin/         
├── Data/         
├── DTO/     
├──Forms/
├── Models/         
├── obj/         
├── Repositories/     
├── Services/
├── Utils/         
├── Data/         
├── DTO/     
├──Forms1.cs
├──Forms1.Designer.cs
├──Forms1.resx
├──Homeform.Designer.cs
├──ItelectFinal.csproj
├──ItelectFinal.csproj.user
├──Mydatabase
├──Program.cs
├──RegisterForm.cs
├──RegisterForm.Designer.cs


**Architecture Layers**

**1.Data Access Layer**

Entities in Models\
  User(Authentication + role).cs
  Customer.cs
  Product.cs
  Order.cs + OrderItem
  Payment.cs
  WorkflowTask.cs

Repositories
 Located in Repositories/
   UserRepository.cs
   CustomerRepository.cs
   ProductRepository.cs
   OrderRepository.cs
   PaymentRepository.cs
   WorkflowTaskRepository.cs
   
       
2.Business Logix Layer
Implements business rules and orchestrates reposity/database operations

 Authentication
   Services/AuthService.cs
     HashPassword() (SHA256)
     Login() sets Utils.Session.CurrentUser
     Register() creates new users with a role
 
 Order Management
   Services/Orderservice.cs
     CreateOrder(...)
     Validate input
     Creates Order + OrderItems and sets TotalAmount
     Creates an initial WorkflowTask if Missing
   UpdateOrderStatus
     Enforces allowed Statuses Pending, Processing, Completed, Cancelled

  Payment Processing
   ServicesNewPaymentAsync(...)
     Validates amount and payment method
     Creates Payment
     Updates the related OrderStatus based on whether it's fully paid
     Calls WorkflowService to advance worklflow tasks immediat

  Workflow / task progression
   Services/WorkflowService.cs
     UpdateWorkflowStatusAsync() updates tasks based on Order.OrderStatus
     UpdateWorkflowStatusForOrderAsync(orderId) updates tasks for a single order

  Reporting
   Services/ReportService.cs
     GetSalesReportAsync() returns SalesReportDTO (total sales + total orders)

  Backup/Restore
   Services/BackupService.cs
    BackupAsync() writes backup.json using DTOs/BackupDTO.cs
    RestoreAsync() reads backup.json and rehydrates entities

3) UI (WinForms Desktop) — root UI + Forms/
Provides the graphical interface and user flows (login, dashboard, CRUD forms).

Entry / navigation

Program.cs
Initializes exception logging
Calls Data.DbInitializer.EnsureCreatedAndSeed()
Launches Form1
Form1.cs / RegisterForm.cs
Login and registration UI
Uses AuthService for authentication
Main dashboard + live updates

HomeForm.cs
Role-based visibility (Admin, Cashier, Prod. Staff / Prod Staff)
Auto-refresh timer (~3 seconds) to:
Refresh sales chart + summary (uses ReportService and also direct EF queries)
Refresh workflow board (uses WorkflowService + WorkflowTaskRepository)
Feature forms

In Forms/:
Orders: OrderForm.cs, AdminOrdersForm.cs
Payments: PaymentForm.cs, AdminPaymentsForm.cs
Customers: CustomerForm.cs
Workflow tasks: WorkflowTaskForm.cs
Reports: ReportsForm.cs

4) Forms
Not present in this repository (this project is a WinForms desktop app using local SQLite).

  Core System Functionality (mapped to the layers)
- User authentication & role handling: Form1/RegisterForm → AuthService → UserRepository/AppDbContext
    Order lifecycle: OrderService enforces allowed status transitions + initializes workflow tasks
    Payment lifecycle: PaymentService records payments, updates order status, advances workflow
    Workflow tracking: WorkflowService keeps WorkflowTask in sync with OrderStatus
    Analytics: ReportService returns SalesReportDTO, displayed in HomeForm
    Backup/restore: BackupService produces/consumes backup.json
    If you want, I can also generate a simple diagram (Mermaid) showing: WinForms UI → Services (BLL) →    Repositories/EF Core (DAL) → SQLite.
 


      
         

 












