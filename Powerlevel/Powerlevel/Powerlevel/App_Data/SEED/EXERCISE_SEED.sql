﻿/* This file is only for populating the lists of exercises, as such a list is exhaustive */
/* Edit Log
2/28/2019
	-REFACTOR: Changed all Singlur instances for table names to Plural
	-REDESIGN: Flag and Equipment tables have been altered into One-To-Many Transaction Tables
*/


/*Items inserted: (If there is an ✖ it means it does not have any pictures)
	ID 1: Bench Press ✓
	ID 2: Bent-over row ✓
	ID 3: Chin-up ✓
	ID 4: Incline flye ✖
	ID 5: Diamond push-up ✓
	ID 6: Dumbell overhead press ✓
	ID 7: Hammer-grip dumbell bench press ✓
	ID 8: Dumbell triceps extension ✓
	ID 9: Lat Pull Down ✓
	ID 10: Leg Press ✓
	ID 11: Lying Leg Curl ✖
	ID 12: Rope Pressdown ✓
	ID 13: Barbell Biceps Curl ✓
	ID 14: Standing Calf Raise ✓
	ID 15: Crunches ✓
	ID 16: Rest ✓
	ID 17: Dumbell Bench Press ✓
	ID 18: Dumbell Flye ✓
	ID 19: Dumbell Lateral Raise ✓
	ID 20: Preacher Curl With Cable ✓
	ID 21: Lying EZ-Bar Triceps Extension ✓
	ID 22: Seated Leg Curl ✓
	ID 23: Seated Calf Raise ✖
	ID 24: Incline Barbell Bench Press ✓
	ID 25: Barbell Rack Upright Row ✓
	ID 26: Dumbell Kickbacks ✓
	ID 27: Single-Arm Neutral-Grip Dumbell Row ✓
	ID 28: Incline Dumbell Biceps Curl ✓
	ID 29: Reverse Crunch ✓
	ID 30: Back Squat ✓
	ID 31: Romanian Deadlift ✓
	ID 32: Push-Ups ✓
	ID 33: Pylo Push-Ups ✓
	ID 34: Ab-Draw Leg Slides ✓
	ID 35: Air Bike ✓
	ID 36: Plank ✓
	ID 37: Lying Knee Raise ✓
	ID 38: Body-Weight Lunges ✓
	ID 39: Body-Weight Side Lunges ✓
	ID 40: Prisoner Squats ✓
	ID 41: Body-Weight Standing Calf Raise ✓

*/
/* Insert into main exercise table */
INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Bench Press', 'Strength', 'Chest',
'Lie on a flat bench, holding a barbell with your hands slightly wider than shoulder-width apart using an overhand grip. 
Brace your core and press your feet into the ground, then lower the bar towards your chest. Press it back up to the start.'),
('Bent-over row', 'Strength', 'Back', 'Hold a barbell using a shoulder-width overhand grip, hands just outside your legs. 
Bend your knees slightly, then bend forwards, hingeing from the hips and keeping your shoulder blades back. 
Pull the bar up towards your sternum, leading with your elbows, then lower it back to the start.'),
('Chin-up', 'Strength', 'Back', 'Hold a chin-up bar using a shoulder-width underhand grip. Brace your core, then pull yourself 
up until your chin is higher than the bar, keeping your elbows tucked in to your body. Lower until your arms are straight again.'),
('Incline flye', 'Strength', 'Chest', 'Lie on an incline bench holding a dumbbell in each hand above your face, with your palms facing 
and a slight bend in your elbows. Lower them to the sides, then bring them back to the top.'),
('Diamond push-up', 'Strength', 'Chest', 'Start in a press-up position but with your thumbs and index fingers touching to form a diamond. 
Keeping your hips up and core braced, bend your elbows to lower your chest towards the floor. Push down through your 
hands to return to the start.'),
('Dumbbell overhead press', 'Strength', 'Anterior Deltoids', 'Sit on an upright bench holding a dumbbell in each hand at shoulder height, 
palms facing forwards. Keeping your chest up, press the weights directly overhead until your arms are straight, then lower them 
back to the start.'),
('Hammer-grip dumbbell bench press', 'Strength', 'Chest', 'Lie on a flat bench, holding dumbbells by your shoulders with palms facing. 
Drive your feet into the floor and press the weights straight up, then lower them slowly back to the start.'),
('Dumbbell triceps extension', 'Strength', 'Triceps', 'Stand tall holding a dumbbell in each hand over your head, arms straight. 
Keeping your chest up, core braced and elbows pointing up, lower the weights behind your head, then return to the start.'),
('Lat Pull Down', 'Strength', 'Back', 'Sit at a lat pulldown station and grab the bar with an overhand grip that is just beyond shoulder width.
Your arms should be completely straight and your torso upright. Pull your shoulder blades down and back, and bring the bar to your chest. 
Pause, then slowly return to the starting position.'),
('Leg Press', 'Strength', 'Legs', 'Adjust the seat of the machine so that you can sit comfortably with your hips beneath your knees and your knees in line with your feet.
Remove the safeties and lower your knees toward your chest until they’re bent 90 degrees and then press back up.
Be careful not to go too low or you risk your lower back coming off the seat (which can cause injury).')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Lying Leg Curl', 'Strength', 'Hamstrings', 'Lie face down on a leg curl machine and hold handles. 
Curl your legs as far as possible, hold for a sec, then curl back down to the starting position.'),
('Rope Pressdown', 'Strength', 'Biceps', 'Facing an adjustable cable machine, grab the rope attachment from the high setting with a thumbs-up grip.
Bring your elbows to your sides so that your forearms are parallel to the floor. Extend your forearms straight down while twisting the rope inward so that your knuckles face the floor when your arms are fully extended.
Pause, then return to the start position.'),
('Barbell Biceps Curl', 'Strength', 'Biceps', 'Grab a barbell with an underhand grip and let it hang with arms fully extended and palms facing forward.
Begin to raise the barbell to your neck level only using your biceps. Once you reach the peak, slowly lower the bar to starting position.' ),
('Standing Calf Raise', 'Warmup', 'Calves', 'Stand in a shoulder-width stance with your toes flat on the edge of a box or step with your heels and mid-foot hanging off the edge so you feel a stretch in your calf. 
Use the wall or a rail as a support to stay balanced. This is your starting position. 
Push your toes into the box so your heels raise up, pause, then lower yourself back to the starting position, being sure to feel a stretch in your calves.'),
('Crunches', 'Strength', 'Abs', 'Lie flat on your back and place your hands behind your head. Bend your knees and firmly plant your feet on the floor.
This is your starting position. With your elbows flared, tighten your abs, and lift your shoulders and upper back off of the floor.
Hold at the top for a second and then retract back down to starting position.'),
('Rest', 'None', 'None', 'Today is a rest day, enjoy time away from the gym.'),
('Dumbell Bench Press', 'Strength', 'Chest', 'Lying on your back on a bench, hold a pair of dumbbells directly above your sternum with your arms fully extended.
Pull your shoulder blades together, slightly stick out your chest, and point your palms forward. Slowly lower both dumbbells to the sides of your chest.
Pause, then press the dumbbells back to the starting position.'),
('Dumbell Flye', 'Strength', 'Chest', 'Grab a pair of dumbbells with an overhand grip and lie face up on a flat bench. 
Extend arms out to sides so that they are parallel to the ground and dumbbells are at chest level. In a controlled motion, raise arms so that palms are facing each other and dumbbells are directly over chest. 
Pause and squeeze chest muscles together at top of movement. Slowly lower the dumbbells in an arc down and away from your body. 
Once the dumbbells are almost in line with chest, reverse the movement back to the starting position.'),
('Dumbell Lateral Raise', 'Strength', 'Delts', 'Standing in a shoulder-width stance, grab a pair of dumbbells with palms facing inward and let them hang at your sides.
Raise your arms out to the sides until they are at shoulder level. Pause, then lower the weights back to the starting position.'),
('Preacher Curl With Cable', 'Strength', 'Biceps', 'Place a preacher bench in front of a cable machine with an EZ-Bar on the lowest setting.
Resting your arms on the padding, hold the bar with both hands, palms facing away from you. Without moving your elbows, curl the bar toward your shoulders. 
Pause, then slowly return the bar to the starting position.')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Lying EZ-Bar Triceps Extension', 'Strength', 'Triceps', 'Lie on your back on a bench while holding a loaded EZ-Bar with an overhand grip, your hands almost shoulder-width apart.
Hold the bar directly above your head with your arms fully extended. Keeping your elbows locked in place, lower the bar until it is about an inch above your forehead.
Pause, then contract your triceps to return the bar to the starting position.'),
('Seated Leg Curl', 'Strength', 'Thighs', 'Sit in a legs curl machine, grasping the handles. Press your legs down as far a possible then return to starting position.'),
('Seated Calf Raise', 'Warmup', 'Calves', 'Sit on a box or bench with your feet flat on the floor in front of you. Flex your calves as high as possible before returning back to the starting position.'),
('Incline Barbell Bench Press', 'Strength', 'Chest', 'Position your body on an incline bench on a 30-45 degree angle. 
Grab a barbell with an overhand grip that is shoulder-width apart and hold it above your chest. Extend arms upward, locking out elbows. Lower the bar straight down in a slow, controlled movement to your chest.
Pause, then press the bar in a straight line back up to the starting position.'),
('Barbell Rack Upright Row', 'Strength', 'Biceps', 'Set the bar in the rack slightly above knee height and grip the bar using a double-overhand grip.
Make sure your palms are facing towards you and your hands are spaced about six inches apart. Raise the bar to chest height, pause, and then slowly lower the weight back to the starting position.'),
('Dumbell Kickbacks', 'Strength', 'Deltoids', 'Kneel over one side of a weight bench by placing one knee and one hand on the bench. Position the standing leg slightly back and to the side with the foot firmly planted on the floor.
The torso should be parallel to the floor. Grab a dumbbell with the free hand with an overhand grip and position the elbow at your side so the upper arm is parallel to the floor.
Keeping the upper arm stationary, extend the arm behind you by contracting the triceps. Pause for one second at the top and then return to the start position.'),
('Single-Arm Neutral-Grip Dumbell Row', 'Strength', 'Biceps', 'Holding a dumbbell in one hand with arm fully extended, bend at the hips until your torso is at approximately a 30-degree angle to the floor.
Without moving your torso, row the dumbbell upward toward your shoulder until it touches your lower chest. Pause, then lower the dumbbell back to start.'),
('Incline Dumbell Bicep Curl', 'Strength', 'Biceps', 'Grab a pair of dumbbells and sit down on an incline bench positioned at a 45-degree angle. 
Pull your shoulder blades back and let the dumbbells hang at your sides with your palms facing forward. Curl the dumbbells up, bending the elbows and bringing both weights to your shoulders. 
Pause, then lower your arms back to starting position.'),
('Reverse Crunch', 'Strength', 'Abs', 'Lie on your back with your knees together and your legs bent to 90 degrees, feet planted on the floor. 
Place your palms face down on the floor for support. Tighten your abs to lift your hips off the floor as you crunch your knees inward to your chest. 
Pause at the top for a moment, then lower back down without allowing your lower back to arch and lose contact with the floor.'),
('Back Squat', 'Strength', 'Glutes', 'Standing in a shoulder-width stance with feet slightly pointed out, rest a loaded barbell across the back of your shoulders holding it with an overhand grip.
Descend into a squat position by pushing your hips back and bending at the knee. At the bottom of the squat, pause, and then drive your hips upward bringing you back to starting position.')
GO


INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Romanian Deadlift', 'Strength', 'Hamstrings', 'Hold the bar in front of your thighs with a shoulder-width grip. Pull it in toward your body—don’t let it drift in front of you. 
Drive your hips back and lower your torso, allowing your knees to bend as needed, until you feel a stretch in your hamstrings. Extend your hips to come back up.'),
('Push-Ups', 'Strength', 'Chest', 'Start off by lying face down on the floor or on a mat with your feet together and arms shoulder width apart. 
Slowly draw your abs in, inhale and raise your body off of the floor until your arms are straight, keeping your head and neck level with your body as this will be your starting position.
As you lower yourself down towards the ground, exhale until your chest almost touches the ground and you feel a stretch in your chest muscles.
Hold for a count at the bottom position and then return back up to the starting position.'),
('Pylo Push-Ups', 'Strength', 'Chest', 'Start off in a prone push up position on the floor with your arms fully extended at shoulder width and keeping your body straight.
Slowly descend to the ground by flexing through your elbows, lowering your chest towards the ground until you feel a tension in your chest.
As soon as you feel a stretch in your muscle quickly push yourself back up so that your hands leave the ground.
Return back to the starting position and repeat for as many reps and sets as desired'),
('Ab-Draw Leg Slides', 'Strength', 'Abs', 'Start off laying on your back with your knees bent at 90 degrees and keeping your arms at your sides, palms up.
Maintaining slight pressure on your hands, extend your legs slowly forward so that you feel a stretch and squeeze on your abdominals.
Return back to the starting position and repeat for as many reps and sets desired.'),
('Air Bike', 'Strength', 'Abs', 'Start off lying flat as if you were going to perform a sit up putting your hands behind your your head and lifting your shoulders into a crunch position.
Bring your knees up so that they are perpendicular with the floor and your lower legs are parallel with the ground as this will be your starting position.
Slowly go through a cycle pedal motion kicking forward with your right leg and bringing in the knee of the left leg.
Next bring your right elbow close to your left knee by crunching to the side.
Return back to the starting position as you breathe in then crunch to the opposite side as you cycle your legs and bring your left elbow close to your right knee.
Repeat with each side for as many reps and sets as desired.'),
('Plank', 'Strength', 'Abs', 'Start off by kneeling on all fours and aligning both hands right below your shoulders keep your knees beneath your hips.
Extend both of your feet out behind you and squeeze on your core muscles, making sure that your body is aligned straight 
Hold this position for about 30 seconds to a minute (or longer depending on the workout).
Release, return back to the starting position and repeat for as many times as you would like to perform this exercise.'),
('Lying Knee Raise', 'Strength', 'Abs', 'Start off laying with your back flat on the floor, arms at your side and feet extended out straight in front of you.
Slowly lift both of your knees up off of the floor and pull them towards your chest. Feel a stretch in your abdominals then return your knees back to the starting position.
Repeat for as many reps and sets as desired.'),
('Bodyweight Lunges', 'Strength', 'Glutes', 'Start off standing up straight with your knees slightly bent then get into a lunge position, and squat down through your hips.
Squat down so that your front leg is parallel with the floor and hold for a count. Return back to the starting position. Repeat for as many reps and sets as desired.'),
('Bodyweight Side Lunges', 'Strength', 'Glutes', 'Start off standing up straight with a slight bend in your knees. Step out to your side with your left leg and squat down through your hips.
Lower yourself towards the floor so that your front leg is parallel with the floor and hold for a count. Return back to the starting position. 
Repeat for as many reps and sets as desired.'),
('Prisoner Squats', 'Strength', 'Upper Legs', 'Start off by standing up straight with wide feet and your hands behind your head.
Slowly lower your body in a controlled squat, extending your hips and knees feeling a stretch in your thighs and glutes.
Return back to the starting position and repeat for as many reps and sets as desired.')
GO

INSERT INTO [dbo].[Exercise]  (Name, Type, MainMuscleWorked, Instructions) VALUES
('Bodyweight Standing Calf Raise', 'Strength', 'Lower Legs', 'Start off setting up either a step or a block next to either a support structure or smith machine.
Place the balls of your feet on the edge of the block/step and let your heels drop down towards the floor as far as possible.
Then slowly raise your heels up as high as possible, squeezing your calves and hold for a count. Return back to the starting position.
Repeat for as many reps and sets as desired.')
GO
GO



/* Insert into flags table, all binary using Sets, Reps, Duration, Distance, Weight*/
INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(1, 'Sets'),(1, 'Reps'),(1, 'Weight'),
(2, 'Sets'),(2, 'Reps'),(2, 'Weight'),
(3, 'Sets'),(3, 'Reps'),
(4, 'Sets'),(4, 'Reps'),(4, 'Weight'),
(5, 'Sets'),(5, 'Reps'),
(6, 'Sets'),(6, 'Reps'),(6, 'Weight'),
(7, 'Sets'),(7, 'Reps'),(7, 'Weight'),
(8, 'Sets'),(8, 'Reps'),
(9, 'Sets'),(9, 'Reps'),(9, 'Weight'),
(10, 'Sets'),(10, 'Reps'),(10, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(11, 'Sets'),(11, 'Reps'),
(12, 'Sets'),(12, 'Reps'),(12, 'Weight'),
(13, 'Sets'),(13, 'Reps'),(13, 'Weight'),
(14, 'Sets'),(14, 'Reps'),
(15, 'Sets'),(15, 'Reps'),
(16, 'Duration'),
(17, 'Sets'),(17, 'Reps'),(17, 'Weight'),
(18, 'Sets'),(18, 'Reps'),(18, 'Weight'),
(19, 'Sets'),(19, 'Reps'),(19, 'Weight'),
(20, 'Sets'),(20, 'Reps'),(20, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(21, 'Sets'),(21, 'Reps'),(21, 'Weight'),
(22, 'Sets'),(22, 'Reps'),(22, 'Weight'),
(23, 'Sets'),(23, 'Reps'),
(24, 'Sets'),(24, 'Reps'),(24, 'Weight'),
(25, 'Sets'),(25, 'Reps'),(25, 'Weight'),
(26, 'Sets'),(26, 'Reps'),(26, 'Weight'),
(27, 'Sets'),(27, 'Reps'),(27, 'Weight'),
(28, 'Sets'),(28, 'Reps'),(28, 'Weight'),
(29, 'Sets'),(29, 'Reps'),
(30, 'Sets'),(30, 'Reps'),(30, 'Weight')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(31, 'Sets'),(31, 'Reps'),(31, 'Weight'),
(32, 'Sets'),(32, 'Reps'),
(33, 'Sets'),(33, 'Reps'),
(34, 'Sets'),(34, 'Reps'),
(35, 'Sets'),(35, 'Reps'),
(36, 'Sets'),(36, 'Duration'),
(37, 'Sets'),(37, 'Reps'),
(38, 'Sets'),(38, 'Reps'),
(39, 'Sets'),(39, 'Reps'),
(40, 'Sets'),(40, 'Reps')
GO

INSERT INTO [dbo].[ExerciseFlag] (ExerciseId, FlagName) VALUES
(41, 'Sets'),(41, 'Reps')
GO

/* Insert into Equipment table, all binary using NoEquipment, Bench, Dumbells, BarbellRack, PullupBar, Spotter*/
INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(1, 'Bench'),(1, 'Barbell Rack'),(1, 'Spotter'),
(2, 'Barbell Rack'),
(3, 'Pullup Bar'),
(4, 'Bench'),(4, 'Dumbells'),
(5, 'No Equipment'),
(6, 'Bench'),(6, 'Dumbells'),
(7, 'Bench'),(7, 'Dumbells'),
(8, 'Dumbells'),
(9, 'Ajustable Cable Machine'),
(10, 'Leg Press Machine')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(11, 'Leg Curl Machine'),
(12, 'Ajustable Cable Machine'),
(13, 'Barbell'),
(14, 'Box'),
(15, 'No Equipment'),
(16, 'No Equipment'),
(17, 'Bench'),(17, 'Dumbells'),
(18, 'Bench'),(18, 'Dumbells'),
(19, 'Dumbells'),
(20, 'Adjustable Cable Machine')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(21, 'EZ-Bar'), (21, 'Bench'),
(22, 'Leg Curl Machine'),
(23, 'Bench'),
(24, 'Bench'), (24, 'Barbell'),
(25, 'Barbell Rack'), (25, 'Barbell'),
(26, 'Dumbells'), (26, 'Bench'),
(27, 'Dumbells'),
(28, 'Dumbells'),(28, 'Bench'),
(29, 'No Equipment'),
(30, 'Bench'), (30, 'Barbell')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(31, 'Barbell'),
(32, 'No Equipment'),
(33, 'No Equipment'),
(34, 'No Equipment'),
(35, 'No Equipment'),
(36, 'No Equipment'),
(37, 'No Equipment'),
(38, 'No Equipment'),
(39, 'No Equipment'),
(40, 'No Equipment')
GO

INSERT INTO [dbo].[ExerciseEquipment] (ExerciseId, EquipmentName) VALUES
(41, 'No Equipment')
GO


/* Insert into Exercise Images table, lookup used for reference */
INSERT INTO [dbo].[ExerciseImage] (ExerciseId, ImageName) VALUES
(1, '1_1.jpg'),
(1, '1_2.jpg'),
(2, '2_1.jpg'),
(2, '2_2.jpg'),
(3, '3_1.jpg'),
(3, '3_2.jpg'),
(5, '5_1.jpg'),
(5, '5_2.jpg'),
(6, '6_1.jpg'),
(6, '6_2.jpg'),
(7, '7_1.jpg'),
(7, '7_2.jpg'),
(8, '8_1.jpg'),
(8, '8_2.jpg'),
(9, '9_1.jpg'),
(9, '9_2.jpg'),
(10, '10_1.jpg'),
(10, '10_2.jpg'),
(12, '12_1.jpg'),
(12, '12_2.jpg'),
(13, '13_1.jpg'),
(13, '13_2.jpg'),
(14, '14_1.jpg'),
(14, '14_2.jpg'),
(15, '15_1.jpg'),
(15, '15_2.jpg'),
(16, '16_1.jpg'),
(17, '17_1.jpg'),
(17, '17_2.jpg'),
(18, '18_1.jpg'),
(18, '18_2.jpg'),
(19, '19_1.jpg'),
(19, '19_2.jpg'),
(20, '20_1.jpg'),
(20, '20_2.jpg'),
(21, '21_1.jpg'),
(21, '21_2.jpg'),
(22, '22_1.jpg'),
(22, '22_2.jpg'),
(24, '24_1.jpg'),
(24, '24_2.jpg'),
(25, '25_1.jpg'),
(25, '25_2.jpg'),
(26, '26_1.jpg'),
(26, '26_2.jpg'),
(27, '27_1.jpg'),
(27, '27_2.jpg'),
(28, '28_1.jpg'),
(28, '28_2.jpg'),
(29, '29_1.jpg'),
(29, '29_2.jpg'),
(30, '30_1.jpg'),
(30, '30_2.jpg'),
(31, '31_1.jpg'),
(31, '31_2.jpg'),
(32, '32_1.jpg'),
(32, '32_2.jpg'),
(33, '33_1.jpg'),
(33, '33_2.jpg'),
(34, '34_1.jpg'),
(34, '34_2.jpg'),
(35, '35_1.jpg'),
(35, '35_2.jpg'),
(36, '36_1.jpg'),
(37, '37_1.jpg'),
(37, '37_2.jpg'),
(38, '38_1.jpg'),
(38, '38_2.jpg'),
(39, '39_1.jpg'),
(39, '39_2.jpg'),
(40, '40_1.jpg'),
(40, '40_2.jpg'),
(41, '41_1.jpg'),
(41, '41_2.jpg')
GO