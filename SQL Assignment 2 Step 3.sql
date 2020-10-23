USE wallysworld;

INSERT INTO orders(`CustomerID`, `ProductID`, `BranchID`, `OrderDate`, `sPrice`, `Status`, `ItemQuantity`) VALUES 
(4, 6, 1, '2019-07-20', 20.93, 'PAID', 4),
(4, 5, 1, '2019-07-20', 9.73, 'PAID', 1),
(4, 3, 1, '2019-07-20', 5.53, 'PAID', 3),
(3, 2, 3, '2019-10-06', 16.73, 'PAID', 10),
(2, 1, 2, '2019-11-02', 18.13, 'PAID', 12),
(2, 3, 2, '2019-11-02', 5.53, 'PAID', 3),
(2, 1, 2, '2019-11-02', 18.13, 'RFND', 12),
(2, 3, 2, '2019-11-02', 5.53, 'RFND', 3);

SELECT * FROM Orders;

SELECT * FROM Products;