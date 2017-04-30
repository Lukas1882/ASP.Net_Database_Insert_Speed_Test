# ASP.Net_Database_Insert_Speed_Test
using differnt scenarios to test the performance when insert big record number

In this project, we are using 3 approaches to test the bulk insert using Entity Framework. For the details, please check my blog **==“Speed Test for Entity Framework (EF) Bulk Insert ( EF-AddRabge VS EF-Utility VS EF-Extension)”==** at [https://www.starwar.io](https://www.starwar.io/blog/2017/04/30/speed-test-for-entity-framework-ef-bulk-insert-ef-addrabge-vs-ef-utility-vs-ef-extension/).

## Test Tools
**==EF AddRange()==**: https://msdn.microsoft.com/en-us/library/system.data.entity.dbset.addrange(v=vs.113).aspx

**==EF utilities 1.0.2==**： https://www.nuget.org/packages/EFUtilities/

**==EF Extensions==**: http://entityframework-extensions.net/


## Test Result
I have run my codes many times, and the results show similar to each other. Please let me know your test result.

**EF AddRanch**: 137942 ms.

**EF Utility BulkInsert** : 3619 ms.

**EF Extension Insert** : 75516 ms.
