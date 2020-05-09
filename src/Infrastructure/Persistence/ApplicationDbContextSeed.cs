﻿using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Doodle;
using CleanArchitecture.Domain.Entities.Quiz;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }

            await SeedQuizRoundsAsync(context);
            await SeedDoodleRoundsAsync(context);
        }

        private static async Task SeedDoodleRoundsAsync(ApplicationDbContext context)
        {
	        if (context.DoodleRounds.Any())
		        return;

	        context.DoodleRounds.Add(new DoodleRound
	        {
		        Name = "General",
		        Difficulty = Difficulty.Easy,
		        Questions = "Banana,Glue,Food,Money,Mop,Hula,Soap,Lipstick,Shopping trolley,Haircut,Trumpet,Butter,Popcorn,Shovel,Penguin,Puppet,Spider man,Mailbox,Cage,Fetch,String,Dog,Stairs,Frankenstein,Goldfish,Coil,Violin,Hoop,Blind,Roof,Bike,Rain,Saddle,Bird,Cape,Alarm,Guitar,Snowball,Table tennis,Fang,Cow,Summer,Rollerblade,Beg,Elbow,Rope,Ball,Wink,Toes,Nap,airplane,cookie,leaf,snowman,bee,grass,swing,chair,pants,cup,horse,circle,legs,sunglasses,ear,car,alligator,blocks,dinosaur,ball,mouse,shirt,bunk bed,lips,socks,chicken,pie,wheel,bunny,eye,square,stairs,egg,worm,skateboard,glasses,lizard,head,cow,monster,hamburger,ocean,bear,bone,monkey,frog,bracelet,lemon,jar,coat,branch,hand,basketball,seashell,person,light,elephant,flower,mountain,door,bat,snake,girl,computer,house,bike,star,milk,caterpillar,pizza,snail,tail,spider web,train,sun,bus,bowl,moon,candle,ghost,boat,jacket,apple,octopus,whale,motorcycle,dragon,bridge,ant,giraffe,truck,helicopter,smile,desk,cherry,mouth,nose,snowflake,face,heart,ring,cat,football,blanket,drum,bread,finger,broom,lollipop,oval,shoe,bench,cloud,feet,boy,bell,banana,doll,crab,bird,bed,butterfly,clock,inchworm,pig,spider,ice cream cone,purse,dog,balloon,eyes,duck,slide,lion,hat,rocket,corn,bug,water,pencil,book,orange,beach,ears,table,spoon,Mickey Mouse,turtle,grapes,cheese,baby,cupcake,hippo,robot,carrot,jellyfish,tree,kite,pen,lamp"
						.Split(',').Select(q => new DoodleQuestion
				        {
					        Question = q
				        }).ToList()
	        });

	        context.DoodleRounds.Add(new DoodleRound
	        {
		        Name = "General",
		        Difficulty = Difficulty.Average,
		        Questions = "Bear,Fly,Brush,Seashell,Tree,Scarf,Jellyfish,See-saw,Hot,Banana,Glue,Food,Money,Mop,Hula,Soap,Lipstick,Shopping trolley,Haircut,Trumpet,Butter,Popcorn,Shovel,Penguin,Puppet,Spider man,Mailbox,Cage,Fetch,String,Dog,Stairs,Frankenstein,Goldfish,Coil,Violin,Hoop,Blind,Roof,Bike,Rain,Saddle,Bird,Cape,Alarm,Guitar,Snowball,Table tennis,Fang,Cow,harp,stingray,thief,chain,key,rose,shadow,brick,platypus,crack,coin,pencil,toothbrush,circus,snowball,cage,watering can,strawberry,suitcase,easel,sink,river,flute,soda,TV,pinwheel,mouse,bicycle,sheep,skirt,glove,tissue,hoof,pajamas,dog leash,beaver,bottle,smoke,iPad,pelican,food,hill,popcorn,ticket,half,t-shirt,blimp,page,lawn mower,whistle,lemon,spider web,pine tree,electrical outlet,cobra,purse,spool,puzzle,bathtub,salt,crib,cheek,tent,wrench,spoon,chalk,coconut,zebra,cell phone,volcano,heel,blowfish,bowtie,alarm clock,match,gingerbread man,light bulb,artist,ice,stoplight,neck,gift,park,cheetah,video camera,hockey,jungle,cake,garbage,starfish,window,claw,outside,tennis,flagpole,mouth,campfire,peach,dimple,headband,back,sea turtle,seesaw,music,mushroom,garden,banana split,crayon,onion,frog,clown,forest,eraser,happy,knee,America,queen,round,silverware,rug,log,tape,dollar,lobster,lighthouse,mail,cucumber,bathroom scale,cello,sunflower,forehead,wall,address,bucket,hair,pan,torch,globe,jewelry,telephone,sprinkler,golf,corndog,vase,pogo stick,chin,daddy longlegs,printer,gumball,fork,lightsaber,owl,spring,paperclip,toe,washing machine,scar,elbow,light switch,surfboard,picture frame,flashlight,shallow,chimney,railroad,seahorse,stork,skate,doormat,mailman,boot,storm,rain,nest,tadpole,eagle,battery,bell pepper,baby,banana peel,rhinoceros,porcupine,smile,spaceship,carpet,whisk,birthday cake,rolly polly,mailbox,king,teeth,grill,jelly,mattress,nail,ring,paint,pineapple,rake,ladybug,blue jeans,aircraft,catfish,spine,shoulder,doghouse,braid,bag,lid,astronaut,horse,cheeseburger,song,pear,electricity,airport,towel,baseball,hair dryer,ship,stamp,popsicle,tusk,hopscotch,chocolate chip cookie,penguin,tulip,soap,coal,gate,refrigerator,swing,corner,sailboat,umbrella,potato,dress,pond,net,room,bib,box,wreath,hummingbird,clam,flamingo,tiger,three-toed sloth,pretzel,manatee,hippopotamus,base,stump,curtains,fishing pole,napkin,toaster,wallet,teapot,maid,nut,mop,magazine,top hat,computer,milk,lawnmower,newspaper,spare,drums,dominoes,brain,dustpan,front porch,hug,wax,face,trash can,chameleon,photograph,wing,skunk,state,mitten,desk,beehive,church,trip,shelf,doorknob,hairbrush,table,hook,trumpet,roller blading,dragonfly,paw,sidewalk,deep,batteries,door,camera,cast,stapler,money,rocking chair,basket,tire,family,apple pie,marshmallow,school,pirate,fang,deer,fur,maze,tongue,watch,unicorn,lock,nature,candle,pumpkin,radish,french fries,fist,shark,stomach,peanut,backbone,ski,ironing board,stove,shovel,bubble,ladder,pen,paper,password,lipstick,pizza,hot dog,barn,calendar,beach,hospital,salt and pepper,lake,eel,lunchbox,piano,cockroach,palace,dolphin,tank,yo-yo,quilt,plate,knot,garage,scissors,snowflake,map,swimming pool,cricket,city,violin,hula hoop,rainbow,wood,dock,laundry basket,mini blinds,waist,cowboy,toast,fox,bomb,poodle,treasure,hip,belt,broccoli,muffin,bagel,roof,attic,button,saw,jar"
						.Split(',').Select(q => new DoodleQuestion
				        {
					        Question = q
				        }).ToList()
	        });

	        context.DoodleRounds.Add(new DoodleRound
	        {
		        Name = "General",
		        Difficulty = Difficulty.Hard,
		        Questions = "Fog,Cactus,Ticket,Taxi,Beast,Huddle,Human,Artist,Giraffe,Honey,Scale,Wax,Cast,Sunburn,Bathroom,Stiff,Chess,Shadow,Cloth,Wig,Doctor,Mirror,Doghouse,Cramp,Bubble,Badge,Knot,Anger,Vegetable,Nightmare,Marble,Washing,Poison,Mouse,Small,Sheet,Trap,Quicksand,Funny,Whisk,Volcano,Eraser,Business,Brain,Blinds,Dryer,Cuff,Flamingo,Basket,Lung,rib,cloak,retail,sandbox,germ,rim,oar,rubber,banister,birthday,dance,leak,shrew,wig,darts,salmon,rind,hydrogen,mast,sneeze,bonnet,snag,safe,Heinz 57,logo,ceiling fan,quicksand,laser,moth,speakers,macaroni,baby-sitter,brand,loveseat,koala,lie,bargain,peasant,saddle,sweater vest,bedbug,important,dust bunny,foil,pizza sauce,clog,point,double,wobble,handle,drawback,password,beanstalk,macho,fiddle,darkness,ringleader,wax,think,baguette,goblin,commercial,welder,exercise,time machine,husband,world,hot tub,lung,season,vitamin,migrate,comfy,dorsal,cardboard,baseboards,mime,drought,taxi,sponge,vegetarian,sunburn,catalog,jazz,runt,hut,chime,ping pong,ski goggles,cruise,cape,ivy,chestnut,pocket,drain,barber,zoo,crow's nest,sleep,dizzy,shampoo,wind,traffic jam,glue stick,nightmare,wag,diagonal,neighborhood,shrink ray,bruise,lap,pro,applause,water buffalo,avocado,dent,dashboard,shower curtain,juggle,bald,myth,picnic,wooly mammoth,whisk,Internet,puppet,cabin,bleach,sheep dog,chess,pilot,swamp,knight,wedding cake,post office,half,plank,cliff,crust,deep,full,pail,mold,plow,tiptoe,dream,mascot,recycle,hurdle,professor,glitter,fog,houseboat,boa constrictor,sushi,jungle,mirror,biscuit,firefighter,grandpa,yardstick,fireside,coach,swarm,caviar,orbit,fizz,gasoline,newsletter,drip,raft,fabric,landscape,dryer sheets,dentist,cell phone charger,lace,chef,yolk,letter opener,bobsled,s'mores,pigpen,cheerleader,bookend,CD,scream,gold,honk,baggage,extension cord,punk,dripping,kneel,hail,bride,ditch,pharmacist,fireman pole,zipper,download"
						.Split(',').Select(q => new DoodleQuestion
				        {
					        Question = q
				        }).ToList()
	        });

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "General",
				Difficulty = Difficulty.ExtraHard,
				Questions = "Satellite,Loyalty,Suit,Love,Revenge,Silhouette,Criticize,Sandbox,Award,Mitten,Feather,Daughter,Crumbs,Lettuce,Dismantle,Train,Evolution,Portfolio,Level,Apathy,Mozart,Lifestyle,Computer monitor,Faucet,Unemployed,Island,Police,Pompous,Tomato sauce,Application,Conversation,Music,Shaft,Explore,Boundary,Olive oil,Tachometer,Shrink,Carpenter,Pendulum,Streamline,Invitation,Teenager,Flag,Jet lag,Personal,Advertise,Journal,Alphabet,Hydrant,kilogram,Chick-fil-A,blueprint,psychologist,intern,tutor,implode,blacksmith,pomp,observatory,inquisition,riddle,gallop,quarantine,chaos,hang ten,brainstorm,stowaway,loiterer,stockholder,parody,password,archaeologist,opaque,addendum,landfill,tournament,con,ice fishing,carat,twang,random,siesta,compromise,default,panic,nutmeg,slump,drift,brunette,acre,transpose,upgrade,reimbursement,mooch,zero,standing ovation,Atlantis,pride,fragment,handful,cartography,offstage,aristocrat,flotsam,lichen,pastry,crisp,neutron,clue,infection,inertia,mine car,champion,flutter,translate,exponential,century,population,Zen,figment,publisher,telepathy,freshwater,soul,rainwater,ligament,snag,eureka,czar,stout,coast,armada,expired,Everglades,overture,ironic,lyrics,blunt,president,tinting,interference,jig,trademark,periwinkle,protestant,philosopher"
						.Split(',').Select(q => new DoodleQuestion
						{
							Question = q
						}).ToList()
			});

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "Animals",
				Difficulty = Difficulty.Easy,
				Questions = "Dragonfly,Ox,Dogfish,Lemur,Zebra,Wolf,Hawk,Lyrebird,Baboon,Hippopotamus,Jaguar,Panda,Toad,Ferret,Louse,Lion,Gaur,Snail,Frog,Raccoon,Cat,Butterfly,Tarsier,Kudu,Hyena,Seahorse,Lark,Bison,Goose,Anteater,Ape,Eland,Weasel,Elk,Falcon,Gnu,Bear,Kangaroo,Goat,Deer,Salamander,Cockroach,Magpie,Bee,Pigeon,Okapi,Leopard,Badger,Crocodile,Snake"
					.Split(',').Select(q => new DoodleQuestion
					{
						Question = q
					}).ToList()
			});

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "Animals",
				Difficulty = Difficulty.Hard,
				Questions = "God,Captain Cook,Robin Hood,Bugs Bunny,Luke Skywalker,Mario,Harry Potter,Leonardo Da Vinci,Bono,Tarzan,Micky Mouse,Babe Ruth,E.T,Optimus Prime,Big Bird,Gandhi,Superman,Mozart,Puss in Boots,Papa Smurf,Harry Houdini,The Hulk,Thomas Jefferson,Andy Griffith,Billy the Kid,Santa Claus,Henry Ford,Vincent Van Gogh,Iron Man,Barbie,Darth Vader,Pablo Picasso,Dr. Seuss,Achilles,Elvis Presley,Sigmund Freud,King Arthur,Voldemort,Scooby Doo,Isaac Newton,The Beatles,Abraham Lincoln,Christopher Columbus ,Kermit the Frog,Snoopy,Shakespeare,Winnie the Pooh,Albert Einstein,Sherlock Holmes,Spider Man,Michael Jackson,Robin Williams,Waldo,Alice (in Wonderland),Bill Cosby,Pablo Picasso,Coldplay,Christopher Columbus,Spider Man,Gilligan,Leonardo DiCaprio,Thomas Jefferson,Winnie the Pooh,Lucille Ball,Kermit the Frog,James Bond,Harrison Ford,Charles Darwin,Amelia Earhart,Beethoven,the Grinch,Shakespeare,Charles Dickens,Oscar the Grouch,Princess Leia,King George,Mary Poppins,Vincent Van Gogh,Abraham Lincoln,Inigo Montoya,Clark Kent,Michael Jordan,Lewis and Clark,Neil Diamond,John Hancock,Babe Ruth,Isaac Newton,Batman,Mozart,Barack Obama,Moby Dick,Frankenstein,Harry Houdini,Audrey Hepburn,Sherlock Holmes,Big Bird,Dr. Seuss,Billy the Kid,Rapunzel,Santa Claus,Plato,Charlie Brown,Rocky,Clifford the Big Red Dog,Mr. Rogers,James Earl Jones,Darth Vader,you,Jim Henson,George of the Jungle,Romeo and Juliet,Anakin Skywalker,Weird Al,Scooby Doo,Andy Griffith,Elmo,Buzz Lightyear,the Beatles,Tony Hawk,Mario,Cap'n Crunch,Alexander Graham Bell,Davy Crockett,Lance Armstrong,Columbus,George Washington,Ben Franklin,Pinocchio,Neil Armstrong,Pablo Piccaso,Luke Skywalker,John Williams,Sean Connery,Peter Pan,Harry Potter,Captain Hook,Socrates,Elvis Presley,Albert Einstein,the Wright brothers,Barbie,Cinderella,Robin Hood,Sonic the Hedgehog,Bill Gates,Dora the Explorer,C. S. Lewis,Thomas Edison,Henry Ford"
					.Split(',').Select(q => new DoodleQuestion
					{
						Question = q
					}).ToList()
			});

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "Movies",
				Difficulty = Difficulty.Average,
				Questions = "The Lion King,Finding Nemo,The Shawshank Redemption,Sleeping Beauty,The Green Mile,Alice in Wonderland,Ratatouille,Apollo 13,The Godfather,Jaws,Rocky,Avatar,Snow White,The Wizard of Oz,The Lord of the Rings,Marry Poppins,Brother Bear,The Little Mermaid,Leon: The Professional,High School Musical,Indiana Jones,Reservoir Dogs,Remember the Titans,James Bond,A Bugs Life,Fight Club,Monty Python and the Holy Grail,The Incredibles,Batman,Tarzan,Toy Story,Star Wars,Shrek,E.T.,The Matrix,The Mighty Ducks,Harry Potter,The Terminator,Cars,The Parent Trap,Dumbo,Full Metal Jacket,Spiderman,Aladdin,The Truman Show,Pirates of the Caribbean,Good Will Hunting,Beauty and the Beast,101 Dalmatians,Willy Wonka and the Chocolate Factory,Madagascar,Teenage Mutant Ninja Turtles,Peter Pan,The Lion King,Little Women,The Santa Clause,Thumbelina,Home Alone,Swiss Family Robinson,Willy Wonka and the Chocolate Factory,The Brave Little Toaster,Robin Hood,Pinocchio,Alice in Wonderland,WALL-E,Singin' in the Rain,Spider-Man,Toy Story,The Incredibles,Tron,The Sandlot,Charlotte's Web,Zorro,Ice Age,The Lord of the Rings,Titanic,The Sword in the Stone,A Bug's Life,James Bond,Cars,Chitty Chitty Bang Bang,James and the Giant Peach,Napoleon Dynamite,Mulan,Cinderella,Tangled,The Wizard of Oz,Free Willy,Remember the Titans,Cheaper by the Dozen,The Princess Bride,Aladdin,High School Musical,Hercules,Bill and Ted's Excellent Adventure,The Mighty Ducks,Bambi,Annie,Rocky,Jaws,Indian in the Cupboard,Back to the Future,Up,Angels in the Outfield,RocketMan,Batman,Monster,Inc.,Pocahontas,Tarzan,Beauty and the Beast,Pete's Dragon,Ratatouille,The Emperor's New Groove,Air Bud,The Little Mermaid,Inception,The Jungle Book,The Sound of Music,Mighty Joe Young,Finding Nemo,Dumbo,The Rescuers,Little Giants,Star Wars,Shrek,Milo and Otis,Snow White and the Seven Dwarves,Newsies,The Princess Diaries,Indiana Jones,Pirates of the Caribbean,The Land Before Time,The Chronicles of Narnia: The Lio,the Witch and the Wardrobe,Mr. Smith Goes to Washington,The Fox and the Hound,Lady and the Tramp,Holes,Hone,I Shrunk the Kids,George of the Jungle,Mary Poppins,101 Dalmatians,Cloudy with a Chance of Meatballs"
					.Split(',').Select(q => new DoodleQuestion
					{
						Question = q
					}).ToList()
			});

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "TV Shows",
				Difficulty = Difficulty.Hard,
				Questions = "SpongeBob SquarePants,South Park,Monk,Buffy the Vampire Slayer,Lost,Supernatural,Wheel of Fortune,That '70s Show,Everybody Hates Chris,Green Lantern: The Animated Series,Animorphs,Hell's Kitchen,Terminator: The Sarah Connor Chronicles,Desperate Housewives,Hey Arnold!,Man vs. Wild,Everybody Loves Raymond,Doctor Who,M*A*S*H,Glee,Charmed,Scooby-Doo,The Biggest Loser,Sonic X,The Drew Carey Show,The Addams Family,Beavis and Butthead,Chuck,House,The A-Team,Charlie's Angels,Batman: The Animated Series,Law & Order,American Dad,ER,Smallville,Home Improvement,Rugrats,Two and a Half Men,How I Met Your Mother,MythBusters,Breaking Bad,The Big Bang Theory,The Simpsons,Star Wars: The Clone Wars,King of the Hill,NCIS,Pokemon,Kim Possible,Grey's Anatomy"
					.Split(',').Select(q => new DoodleQuestion
					{
						Question = q
					}).ToList()
			});

			context.DoodleRounds.Add(new DoodleRound
			{
				Name = "Books",
				Difficulty = Difficulty.ExtraHard,
				Questions = "To Kill A Mockingbird by Harper Lee,The Eagle Has Landed by Jack Higgins,A Tale of Two Cities by Charles Dickens,The Da Vinci Code by Dan Brown,James Bond by Ian Fleming,The Hobbit by J. R. R. Tolkien,White Fang by Jack London,The Call of the Wild by Jack London,La Confidential by James Ellroy ,Harry Potter by J. K. Rowling,Peter Rabbit by Beatrix Potter,Lord of the Flies by William Golding ,Anna Karenina by Leo Tolstoy ,The Scarlet Letter by Nathaniel Hawthorne ,The Catcher in the Rye by J. D. Salinger,The Godfather by Mario Puzo,The Lord Of The Rings by J. R. R. Tolkien,Ulysses by James Joyce ,The Cat in the Hat by Dr. Seuss,The Wind in the Willows by Kenneth Grahame ,Charlie and the Chocolate Factory by Roald Dahl,Charlotte's Web by E. B. White ,The Picture of Dorian Gray by Oscar Wilde,Watership Down by Richard Adams,Catch-22 by Joseph Heller,Twilight by Stephenie Meyer,The Great Gatsby by F. Scott Fitzgerald ,The Neverending Story by Michael Ende,David Copperfield by Charles Dickens,Alice's Adventures In Wonderland by Lewis Carroll ,And Then There Were None by Agatha Christie,Winnie-the-Pooh by A. A. Milne,Huckleberry Finn by Mark Twain ,The Lion the Witch and the Wardrobe - C. S. Lewis,Frankenstein by Mary Shelley ,Emma by Jane Austen,Moby-Dick by Herman Melville,Curious George by Hans Augusto Rey and Margret Rey,Hitchhiker's Guide to the Galaxy by Douglas Adams,Where the Wild Things Are by Maurice Sendak,Jaws by Peter Benchley,To Kill A Mockingbird by Harper Lee,The Eagle Has Landed 	by Jack Higgins,A Tale of Two Cities by Charles Dickens,The Da Vinci Code by Dan Brown,James Bond by Ian Fleming,The Hobbit by J. R. R. Tolkien,White Fang by Jack London,The Call of the Wild by Jack London,La Confidential by James Ellroy"
					.Split(',').Select(q => new DoodleQuestion
					{
						Question = q
					}).ToList()
			});

        }
		
        private static async Task SeedQuizRoundsAsync(ApplicationDbContext context)
        {
	        if (context.QuizRounds.Any())
		        return;

	        context.QuizRounds.Add(new QuizRound
	        {
		        Name = "General Knowledge",
                Difficulty = Difficulty.Hard,
		        Questions =
		        {
			        new QuizQuestion
			        {
				        Question = "What is the most consumed Manufactured drink in the world?",
				        Type = QuizQuestionType.SingleChoice,
				        Answers =
				        {
					        new QuizAnswer {Answer = "Coke", IsCorrect = true},
					        new QuizAnswer {Answer = "Tea", IsCorrect = false},
					        new QuizAnswer {Answer = "Bear", IsCorrect = false},
					        new QuizAnswer {Answer = "Wine", IsCorrect = false},
				        }
			        },
			        new QuizQuestion
			        {
				        Question = "Which country manufactures the most Cars?",
				        Type = QuizQuestionType.SingleChoice,
				        Answers =
				        {
					        new QuizAnswer {Answer = "Germany", IsCorrect = false},
					        new QuizAnswer {Answer = "India", IsCorrect = false},
					        new QuizAnswer {Answer = "USA", IsCorrect = false},
					        new QuizAnswer {Answer = "China", IsCorrect = true}
				        }
			        }
                }
	        });
			//TODO
			var a =@"Which country manufactures the most Cars?
Germany
India
USA
[x]China";

			context.QuizRounds.Add(new QuizRound
	        {
		        Name = "Geography",
		        Difficulty = Difficulty.Easy,
		        Questions =
		        {
			        new QuizQuestion
			        {
				        Question = "What is the capital city of Canada?",
				        Type = QuizQuestionType.SingleChoice,
				        Answers =
				        {
					        new QuizAnswer {Answer = "Calgary", IsCorrect = false},
					        new QuizAnswer {Answer = "Ottawa", IsCorrect = true},
					        new QuizAnswer {Answer = "Toronto", IsCorrect = false},
					        new QuizAnswer {Answer = "Vancouver", IsCorrect = false},
				        }
			        },
			        new QuizQuestion
			        {
				        Question = "What colours make up the Finish flag?",
				        Type = QuizQuestionType.SingleChoice,
				        Answers =
				        {
					        new QuizAnswer {Answer = "White & Blue", IsCorrect = true},
					        new QuizAnswer {Answer = "Yellow & Blue", IsCorrect = false},
					        new QuizAnswer {Answer = "Red & White", IsCorrect = false}
				        }
			        }
		        }
	        });

			await context.SaveChangesAsync();
		}
    }
}
