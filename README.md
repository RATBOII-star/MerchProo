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

### 1. Data Access Layer
Handles all database operations using Entity Framework Core with SQLite.

- **Entities/** - Domain models
  - `User.cs` - (Authentication + role)
  - `Customer.cs`
  - `Product.cs`
  - `Order.cs` + `OrderItem.cs`
  - `Payment.cs`
  - `WorkflowTask.cs`

- **Repositories/** - Data access patterns
  - `UserRepository.cs`
  - `CustomerRepository.cs`
  - `ProductRepository.cs`
  - `OrderRepository.cs`
  - `PaymentRepository.cs`
  - `WorkflowTaskRepository.cs`

- **Migrations/** - Database schema versioning
   
### 2. Business Logic Layer (BLL)
Implements business rules and orchestrates repository/database operations.

- **Authentication** - `Services/AuthService.cs`
  - `HashPassword()` - (SHA256)
  - `Login()` - Sets `Utils.Session.CurrentUser`
  - `Register()` - Creates new users with a role

- **Order Management** - `Services/OrderService.cs`
  - `CreateOrder(...)` - Validates input
  - Creates `Order` + `OrderItems` and sets `TotalAmount`
  - Creates an initial `WorkflowTask` if missing
  - `UpdateOrderStatus` - Enforces allowed statuses: `Pending`, `Processing`, `Completed`, `Cancelled`

- **Payment Processing**
  - `Services/NewPaymentAsync(...)` - Validates amount and payment method
  - Creates `Payment` record
  - Updates the related `OrderStatus` based on whether it's fully paid
  - Calls `WorkflowService` to advance workflow tasks immediately

- **Workflow / Task Progression** - `Services/WorkflowService.cs`
  - `UpdateWorkflowStatusAsync()` - Updates tasks based on `Order.OrderStatus`
  - `UpdateWorkflowStatusForOrderAsync(orderId)` - Updates tasks for a single order

- **Reporting** - `Services/ReportService.cs`
  - `GetSalesReportAsync()` - Returns `SalesReportDTO` (total sales + total orders)

- **Backup / Restore** - `Services/BackupService.cs`
  - `BackupAsync()` - Writes `backup.json` using `DTOs/BackupDTO.cs`
  - `RestoreAsync()` - Reads `backup.json` and rehydrates entities

### 3. UI Layer (WinForms Desktop) — root UI + Forms/
Provides the graphical interface and user flows (login, dashboard, CRUD forms).

- **Entry / Navigation** - `Program.cs`
  - Initializes exception logging
  - Calls `Data.DbInitializer.EnsureCreatedAndSeed()`
  - Launches `Form1.cs`
  - `Form1.cs` / `RegisterForm.cs` - Login and registration UI
  - Uses `AuthService` for authentication
  - Main dashboard + live updates

- **Home Dashboard** - `HomeForm.cs`
  - **Role-based visibility** - (Admin, Cashier, Prod. Staff)
  - **Auto-refresh timer** (~3 seconds) to:
    - Refresh sales chart + summary (uses `ReportService` and direct EF queries)
    - Refresh workflow board (uses `WorkflowService` + `WorkflowTaskRepository`)

- **Feature Forms** - Located in `Forms/`
  - **Orders:** `OrderForm.cs`, `AdminOrdersForm.cs`
  - **Payments:** `PaymentForm.cs`, `AdminPaymentsForm.cs`
  - **Customers:** `CustomerForm.cs`
  - **Workflow tasks:** `WorkflowTaskForm.cs`
  - **Reports:** `ReportsForm.cs`

4) Forms
Not present in this repository (this project is a WinForms desktop app using local SQLite).

- Core System Functionality (mapped to the layers)
 - User authentication & role handling: Form1/RegisterForm → AuthService → UserRepository/AppDbContext
 - Order lifecycle: OrderService enforces allowed status transitions + initializes workflow tasks
 - Payment lifecycle: PaymentService records payments, updates order status, advances workflow
 - Workflow tracking: WorkflowService keeps WorkflowTask in sync with OrderStatus
 - Analytics: ReportService returns SalesReportDTO, displayed in HomeForm
 - Backup/restore: BackupService produces/consumes backup.json
 - If you want, I can also generate a simple diagram (Mermaid) showing: WinForms UI → Services (BLL) →    Repositories/EF Core (DAL) → SQLite.


 1. User Authentication & Authorization
- Login screen: Form1 authenticates users via AuthService.Login(username, password)
- Password security: passwords are hashed with SHA256 (AuthService.HashPassword)
- Role handling: user role is stored in Session.CurrentUser.Role and the dashboard UI changes what actions/forms are shown
UI checks roles like Admin, Cashier, Prod. Staff (also Prod Staff)
- Note: self-registration (RegisterForm) creates users with the default role User (so if you need Cashier/Prod. Staff, you’d typically change the role in the database)

2. Customer & Product Management

- Customers: add customers through CustomerForm (stored in SQLite via EF Core repositories)
Products: seeded automatically at startup (e.g., T-Shirt, Cap, Mug, Tote Bag, Notebook)

3. Order Management

- Create orders from OrderForm
- Business rules enforced by OrderService
- Creates Order + OrderItems
- Sets OrderStatus to Pending initially
- Validates allowed statuses when updating (Pending, Processing, Completed, Cancelled)
- Orders are displayed/consumed across the UI and drive workflow state updates

4. Payment System
Record payments via PaymentForm
PaymentService logic:
Validates payment input
Saves Payment
Updates the linked OrderStatus:
Completed when amountPaid >= order.TotalAmount
otherwise Processing
Advances workflow tasks immediately using WorkflowService

5. Workflow Tracking

Workflow tasks are stored in WorkflowTask and updated by WorkflowService

HomeForm auto-refreshes every ~3 seconds and shows:
Pending / InProgress / Completed workflow lists
Workflow state is derived from each order’s OrderStatus

6. Analytics & Reporting (Dashboard)
- ReportService.GetSalesReportAsync() returns simple metrics:
Total sales, total orders
- HomeForm builds a sales chart from Payments grouped by date (last 7 days)

7. Backup / Restore (Internal Service)
BackupService can export/import backup.json using BackupDTO
This exists in Services/BackupService.cs, but I don’t see it wired into a UI form in the current project.
Login Instructions (Desktop App)
Default Test Accounts (pre-seeded)
The app seeds only the following user by default on first run:

Username	Password	Role
admin	admin123	Admin
Creating Other Accounts
Use the Sign Up button in the app (RegisterForm)
Newly registered users get role User by default (not Cashier / Borrower / etc. — those roles don’t exist in this system)
Admin accounts must be created directly in the database if you want additional Admin users (or you can modify role values after registration)
How to Run / Login (WinForms)
Run the desktop app:
dotnet run --project ITelectFinal.csproj
Login with:
admin / admin123



      
         

 












