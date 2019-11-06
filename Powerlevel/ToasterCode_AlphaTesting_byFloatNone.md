# Alpha Testing

## Toaster Code

## Vision Statement

For people who want to get in shape or work out, the rpg-lite workout is a workout planning platform that integrates rpg elements into a workout plan. The webapp gives the user a workout plan customized and curated by them while providing a gamified interface and spin to all fitness activities that resembles a role playing game. Unlike other gamified applications, our product will both focus only on a fitness experience and provide the user with state recommend workouts in a fun, social format.

### powerlevel.azurewebsites.net

### Testing Accounts

        tester5

        I_Am_Tester_5

        tester6

        I_Am_Tester_6

        tester7

        I_Am_Tester_7

        tester8

        I_Am_Tester_8

## Bug Reports

_Testers: Write your handwritten reports by following this pattern_

__[Bug]__ This is a good description of a bug (prefix with [Bug]) where I will tell you what the conditions were for the bug to occur and then what the failure was.  Include:

    1. Starting condition, setup or scenario

    2. Steps to replicate the failure

    3. Actual result

    4. Expected result

    5. Remarks

    

Most importantly: __be specific!__

__[Deficiency]__ Report a deficiency with this tag.  A deficiency is a behavior of the application that is functionally correct (not a failure) but is deficient in some manner; or a feature or behavior that is expected but not present.  This can include a feature of the website that does not meet the expectations generated by the vision statement.

__[Presentation]__ This is how you can report problems with the application's user interface.  Is there something in the presentation that isn't clear, intuitive or an example of good UI design?  Do you like the colors, fonts, layout?  Does it make sense?  

__[Recommendation]__ Give the development team a recommendation.

 

Actual reports start here …

[10]__[Presentation]__[Brock]

It’s unclear what actually happens when you click the "Team Up" button on another user’s profile page, as clicking on it takes you straight to your own profile, with no other feedback.

[Steps]

1. Log in under any account at: [http://powerlevel.azurewebsites.net/](http://powerlevel.azurewebsites.net/)

2. Navigate to: [http://powerlevel.azurewebsites.net/Ranking](http://powerlevel.azurewebsites.net/Ranking)

3. Click on any user’s name other than the user you are logged in as

4. Click the "Team Up" button

[9]__[Recommendation]__[Brock]

Remove / hide the "Team Up" button entirely when viewing your own profile via the ‘Rankings’ page. It doesn’t do anything when you click on it, but is still showing.

[8]__[Deficiency]__[Brock]

Users are able to select a date past the current date for their birthdate.

[Steps]

1. Navigate to [http://powerlevel.azurewebsites.net/Account/Register](http://powerlevel.azurewebsites.net/Account/Register)

2. Select the ‘BirthDate’ element

3. Click the month + year at the top of the box

4. Click the year at the top of the box

5. Select any year and day past the current date

[7]__[Presentation]__[Brock]

When registering for a new account, the calendar for selecting your birthdate is smooshed and cluttered.

[Steps]

1. Navigate to [http://powerlevel.azurewebsites.net/Account/Register](http://powerlevel.azurewebsites.net/Account/Register)

2. Select the ‘BirthDate’ element

3. Click on the month + year at the top of the box

4. Click the year at the top of the box

5. Click the year at the top of the box again

[6]__[Recommendation]__[Khorben]

When on the "SetWeapon" page the button at the bottom says “Select Armor”.

This should probably be changed to "Select Weapon".

1. Navigate to the "SetWeapon" page: [http://powerlevel.azurewebsites.net/Manage/SetWeapon](http://powerlevel.azurewebsites.net/Manage/SetWeapon)

2. Notice that while the page is "SetWeapon" the button is labeled as “Select Armor”.

3. "Select Armor" should probably be “Select Weapon”?

[5]__[Presentation]__[Stuart]

When shrinking a page, the ‘Log Off’ and Account Settings disappear before the drop down option shows up. As you are unable to scroll horizontally, you cannot click the two buttons. This occurs when shrinking the page from the full-screen view from the top-right corner of the window. As you slowly make it smaller moving towards the bottom-left corner, the log off button and name button disappear.

[Steps]

1. Log in under any account at: [http://powerlevel.azurewebsites.net/](http://powerlevel.azurewebsites.net/)

2. Adjust the window size from the top-right corner, slowly moving it to the bottom-left corner. Buttons in the top-right corner (e.g. Log Out) will not be clickable until the whole view shrinks and the drop-down menu becomes available.

[4]__[Bug]__[Stuart]

Cannot change heights of avatars to x’10" or x’11”, where x = < 1

[Steps]

1. Go to Manage Account Settings: http://powerlevel.azurewebsites.net/Manage

2. Go to Metrics: Adjust Metrics

3. Attempt to set height to any foot, with the inces as 10 or 11.

[3]__[Recommendation]__[Khorben]

1. Go to "Change Body" option page for avatars: [http://powerlevel.azurewebsites.net/Manage/SetAvatar](http://powerlevel.azurewebsites.net/Manage/SetAvatar)

2. One can select a body type by finding and clicking the radio button embedded in a given image. This is hard to see and not intuitive.

3. Recommend make the whole picture for a given body selectable with color change, highlighting, or other means of indicating your choice.

[2]__[Deficiency]__[Stuart]

The Exercise/Details page returns a Bad Request error page if there is no ID added at the end of the URL.

1. Navigate to [http://powerlevel.azurewebsites.net/Exercise/Details/](http://powerlevel.azurewebsites.net/Exercise/Details/)

2. ‘Bad Request’ page displays

[1]__[Presentation]__[Stuart]

The text on the exercise details are difficult to read, as the headers and text are the same color and font size/style. I would recommend at least a font color change or size change.

[Steps]

1. Navigate to [http://powerlevel.azurewebsites.net/Exercise/](http://powerlevel.azurewebsites.net/Exercise/)

2. Click a ‘How To’ option

3. View the text on the page before the pictures
