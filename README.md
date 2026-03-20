# MerchProo: Merchandise Production Management System with POS and Workflow Tracking 

SDG Goal 8: Decent Work and Economic Growth & SDG Goal 9: Industry, Innovation, and Infrastructure

Problem Statement

Small merchandise and apparel businesses often struggle with fragmented operations, relying on manual logs or disconnected spreadsheets. This leads to untracked order statuses, frequent errors in sales recording, and an inability to monitor production bottlenecks. MerchPro solves this by integrating Order Management, Workflow Tracking, and POS into a single secure platform, fostering digital transformation and operational efficiency for small-scale industries.

Overview

The project is designed to simulate an enterprise-level development environment. It is not merely a coding exercise but a rigorous demonstration of software engineering principles, requiring students to bridge the gap between high-level architectural design and low-level technical implementation. The final output must be a robust, persistent, and secure utility capable of managing complex data relationships and delivering actionable insights for social or environmental impact.

The system supports Sustainable Development Goal 8 (Decent Work and Economic Growth) by improving business efficiency, supporting small-scale merchandise operations, and enabling better job productivity through automation and organized workflows.

It promotes economic growth by

- Streamlining order and payment processes

- Improving production efficiency through workflow tracking

- Supporting business decision-making using sales reports

- Reducing manual errors and workload for employees

System Architecture

ITelectFinal/
  bin/
  obj/
  

  Data/
    AppDbContext.cs
    DbInitializer.cs
    DbPath.cs
    

  DTOs/
    BackupDTO.cs
    SalesReportDTO.cs
    

  Forms/
    AdminOrdersForm.cs
    AdminOrdersForm.Designer.cs
    AdminPaymentsForm.cs
    AdminPaymentsForm.Designer.cs
    CustomerForm.cs
    CustomerForm.Designer.cs
    CustomerForm.resx
    OrderForm.cs
    OrderForm.Designer.cs
    PaymentForm.cs
    PaymentForm.Designer.cs
    ReportsForm.cs
    ReportsForm.Designer.cs
    WorkflowTaskForm.cs
    WorkflowTaskForm.Designer.cs
    

  Models/
    Customer.cs
    Order.cs
    OrderItem.cs
    Payment.cs
    Product.cs
    User.cs
    WorkflowTask.cs
    

  Repositories/
    CustomerRepository.cs
    OrderRepository.cs
    PaymentRepository.cs
    ProductRepository.cs
    UserRepository.cs
    WorkflowTaskRepository.cs
    

  Services/
    AuthService.cs
    BackupService.cs
    OrderService.cs
    PaymentService.cs
    ReportService.cs
    WorkflowService.cs
    

  Utils/
    Logger.cs
    Session.cs
    

  Form1.cs
  Form1.Designer.cs
  Form1.resx
  RegisterForm.cs
  RegisterForm.Designer.cs
  HomeForm.cs
  HomeForm.Designer.cs
  

  Program.cs
  ITelectFinal.csproj
  ITelectFinal.csproj.user
  Mydatabase.db

