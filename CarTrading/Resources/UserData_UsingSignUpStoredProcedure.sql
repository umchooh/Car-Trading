USE Car_Trading
--UPDATED ON OCT 25,2024
-- USER DATA THRU STORED PROCEDURE - SignUp
/************************************************************* ADMIN

DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Choo123',
    @Roletype = 'Admin',
    @Password = 'Choo@123',
    @Email = 'Choo123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Nicolas123',
    @Roletype = 'Admin',
    @Password = 'Nicolas@123',
    @Email = 'Nicolas123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'John123',
    @Roletype = 'Admin',
    @Password = 'John@123',
    @Email = 'John123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Mark123',
    @Roletype = 'Admin',
    @Password = 'Mark@123',
    @Email = 'Mark123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;

*/

/******************************************************* REGULAR
DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Diana123',
    @Roletype = 'Regular',
    @Password = 'Diana@123',
    @Email = 'diana123@regular.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;

DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Mark456',
    @Roletype = 'Regular',
    @Password = 'Mark@456',
    @Email = 'mark456@regular.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Melly Breznovic',
    @Roletype = 'Regular',
    @Password = 'Melly@123',
    @Email = 'mbreznovic0@microsoft.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Norina Buttrey',
    @Roletype = 'Regular',
    @Password = 'Norina@123',
    @Email = 'nbuttrey1@tiny.cc',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Lavinia Miettinen',
    @Roletype = 'Regular',
    @Password = 'Lavinia@123',
    @Email = 'lmiettinen2@ycombinator.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Gabe Benedict',
    @Roletype = 'Regular',
    @Password = 'Gabe@123',
    @Email = 'gbenedict3@techcrunch.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Lionel Storkes',
    @Roletype = 'Regular',
    @Password = 'Lionel@123',
    @Email = 'lstorkes4@hhs.gov',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Janaye Thorneywork',
    @Roletype = 'Regular',
    @Password = 'Janaye@123',
    @Email = 'jthorneywork5@scientificamerican.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Earle Tregea',
    @Roletype = 'Regular',
    @Password = 'Earle@123',
    @Email = 'etregea6@tinyurl.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Claudian Labb',
    @Roletype = 'Regular',
    @Password = 'Claudian@123',
    @Email = 'clabb7@state.tx.us',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Fayina Rantoul',
    @Roletype = 'Regular',
    @Password = 'Fayina@123',
    @Email = 'frantoula@telegraph.co.uk',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Faustina Shoebottom',
    @Roletype = 'Regular',
    @Password = 'Faustina@123',
    @Email = 'fshoebottomb@msu.edu',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Clementina Horwell',
    @Roletype = 'Regular',
    @Password = 'Clementina@123',
    @Email = 'chorwellc@geocities.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Putnem McDonnell',
    @Roletype = 'Regular',
    @Password = 'Putnem@123',
    @Email = 'pmcdonnelld@ehow.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Camala Rubenfeld',
    @Roletype = 'Regular',
    @Password = 'Camala@123',
    @Email = 'crubenfelde@vk.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Far Baldelli',
    @Roletype = 'Regular',
    @Password = 'Far@123',
    @Email = 'fbaldellif@github.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Patrica Cracker',
    @Roletype = 'Regular',
    @Password = 'Patrica@123',
    @Email = 'pcrackerg@tumblr.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Jeannette Whall',
    @Roletype = 'Regular',
    @Password = 'Jeannette@123',
    @Email = 'jwhallh@php.net',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Marilyn Fink',
    @Roletype = 'Regular',
    @Password = 'Marilyn@123',
    @Email = 'mfinki@xinhuanet.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Florrie Priddy',
    @Roletype = 'Regular',
    @Password = 'Florrie@123',
    @Email = 'fpriddyj@google.ru',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Frasco Kennewell',
    @Roletype = 'Regular',
    @Password = 'Frasco@123',
    @Email = 'fkennewelln@geocities.jp',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Lisette Vickars',
    @Roletype = 'Regular',
    @Password = 'Lisette@123@123',
    @Email = 'lvickarsm@issuu.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Natividad Crutchfield',
    @Roletype = 'Regular',
    @Password = 'Natividad@123',
    @Email = 'ncrutchfieldl@themeforest.net',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Vikky Conklin',
    @Roletype = 'Regular',
    @Password = 'Vikky@123',
    @Email = 'vconklink@drupal.org',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;

*/

/******************************************************* DEALER

DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Jay123',
    @Roletype = 'Dealer',
    @Password = 'Jay@123',
    @Email = 'Jay123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Kevin',
    @Roletype = 'Dealer',
    @Password = 'Kevin@123',
    @Email = 'Kevin123@example.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Jean123',
    @Roletype = 'Dealer',
    @Password = 'Jean@123',
    @Email = 'Jean123@dealer.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Kahaleel Robertis',
    @Roletype = 'Dealer',
    @Password = 'Kahaleel@123',
    @Email = 'krobertis8@naver.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Welbie Cornels',
    @Roletype = 'Dealer',
    @Password = 'Welbie@123',
    @Email = 'wcornels9@dyndns.org',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Broddy Diviny',
    @Roletype = 'Dealer',
    @Password = 'Brody@123',
    @Email = 'bdivinyt@hibu.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;

DECLARE @Result INT;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Clause Labb',
    @Roletype = 'Dealer',
    @Password = 'Clause@123',
    @Email = 'clabb7@state.tx.us',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Quinn Barnwill',
    @Roletype = 'Dealer',
    @Password = 'Quinn@123',
    @Email = 'qbarnwillo@ucoz.ru',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Carin Cotelard',
    @Roletype = 'Dealer',
    @Password = 'Carin@123',
    @Email = 'ccotelardp@eventbrite.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'North Cobbled',
    @Roletype = 'Dealer',
    @Password = 'North@123',
    @Email = 'ncobbledq@freewebs.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;


DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'Rollo Halpeine',
    @Roletype = 'Dealer',
    @Password = 'Rollo@123',
    @Email = 'rhalpeiner@nationalgeographic.com',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;



DECLARE @Result INT;

EXEC [dbo].[SignUp]
    @Username = 'amurrishs@joomla.org',
    @Roletype = 'Dealer',
    @Password = 'Allen@1233',
    @Email = 'Allen Murrish',
    @result = @Result OUTPUT;

-- Check the result
SELECT @Result AS SignUpResult;

*/


---------------------------------------------------------
-- SELECT * FROM Users;

-- You can check using Login Stored Procedure below
/*
DECLARE @LoginResult INT;

EXEC [dbo].[Login]
    @Username = 'Choo123',       -- Replace with the actual username
    @Password = 'Choo@123',     -- Replace with the actual password
    @Result = @LoginResult OUTPUT;

-- Check the result
SELECT @LoginResult AS LoginResult;

*/

