drop table if exists users;
drop table if exists noun_object;
drop table if exists noun_place;
drop table if exists week_time;
drop table if exists verb_groups;
drop table if exists particles;
drop table if exists conjugation;
drop table if exists numbers;
drop table if exists special;
drop table if exists patterns;
drop table if exists sentences;
drop table if exists kanji;

create table users
(
user_index  int identity(1, 1),
user_hira	nvarchar(40),
user_eng	nvarchar(40),
user_kata	nvarchar(40)
);

create table noun_object
(
object_index	int identity(1,1),
object_hira	nvarchar(50),
object_eng	nvarchar(50),
object_kata	nvarchar(50)
);

create table noun_place
(
place_index	int identity(1,1),
place_hira	nvarchar(50),
place_eng	nvarchar(50),
place_kata	nvarchar(50)
);

create table week_time
(
week_day_index	int identity(1,1),
week_day_hira	nvarchar(20),
week_day_eng	nvarchar(20),
week_day_kata	nvarchar(20)
);

create table verb_groups
(
verb_index	int identity(1,1),
verb_hira	nvarchar(50),
verb_eng	nvarchar(50),
verb_group	int
);

create table particles
(
particle_index	int identity(1,1),
particle_hira	nvarchar(50),
particle_eng	nvarchar(50),
particle_kata	nvarchar(50)
);

create table conjugation
(
conjugation_index	int identity(1,1),
conjugation_hira	nvarchar(60),
conjugation_eng		nvarchar(60)
);

create table numbers
(
number_index int identity(1,1),
number_hira nvarchar(50),
number_eng	nvarchar(50)
);

create table patterns
(
pattern_index	int identity(1,1),
pattern_design	nvarchar(200),
pattern_example	nvarchar(200)
);

create table special
(
special_index	int identity(1,1),
special_hira	nvarchar(100),
special_eng		nvarchar(100),
);

create table sentences
(
sentence_index int identity(1,1),
sentence_hira	nvarchar(200),
sentence_eng	nvarchar(200)
);

create table kanji
(
kanji_index int identity(1,1),
kanji_kanji	nvarchar(50),
kanji_eng	nvarchar(50)
);

insert into users(user_hira,user_eng,user_kata) VALUES(N'だん','Dan',N'ダン'),
(N'しょくどうのひと','School staff', 'no equivelant'),
(N'せんせい','Teacher','no equivelant'),
(N'ありす','Alice',N'アリス'),
(N'るいＮ','Ruin',N'ルイン'),
(N'もも','Momo',N'モモ'),
(N'なると','Naruto',N'ナルト'),
(N'さくら','Sakura',N'サクラ'),
(N'ゆり','Yuri',N'ユリ'),
(N'わたし','Me','no equivelant'),
(N'あなた','You','no equivelant');

insert into noun_object(object_hira, object_eng, object_kata) values
(N'ごはん','Rice','no equivelant'),
(N'きょうかしょ','Textbook','no equivelant'),
(N'ていぷ','Tape',N'テオプ'),
(N'さかなふらいでいしょく','Fried fish set meal','no equivelant'),
(N'しょくどうのひと','School staff','no equivelant'),
(N'れじ','Cashier','no equivelant'),
(N'えん','Yen','no equivelant'),
(N'さらだ','Salat',N'サラダ'),
(N'ほん','Book','no equivelant'),
(N'しんぶん','Newspaper','no equivelant'),
(N'さかな','Fish','no equivelant'),
(N'かんじ','Kanji','no equivelant'),
(N'ひらがな','Hiragana','no equivelant'),
(N'にほんご','Japanese language','no equivelant'),
(N'ざつし','Magazine',N'ザツシ'),
(N'ぶんぽう','Grammar','no equivelant'),
(N'らじお','Radio',N'ラヂオ'),
(N'さんどいつち','Sandwich',N'サンドイツチ'),
(N'かれいらいす','Curry Rice','no equivelant'),
(N'てれび','Television',N'テレビ'),
(N'こうひい','Coffee',N'コーヒイ'),
(N'おんがく','Music','no equivelant'),
(N'しょうかい','An introduction','no equivelant'),
(N'おんな','Woman','no equivelant'),
(N'あともだち','Your friend','no equivelant'),
(N'ともだち','Friend','no equivelant');

insert into noun_place(place_hira,place_eng,place_kata) values
(N'だいがく','University','no equivelant'),
(N'しょくどう','Cafeteria','no equivelant'),
(N'りゅがくせいかいかん','International students house','no equivelant'),
(N'きょうしつ','Classroom','no equivelant'),
(N'けんきゅうしつ','Professors house/laboratory','no equivelant'),
(N'としょかん','Library','no equivelant'),
(N'かいかん','House(For international students)','no equivelant'),
(N'おくに','Your country','no equivelant'),
(N'くに','Country','no equivelant');

insert into week_time(week_day_hira,week_day_eng, week_day_kata) values
(N'きのう','Yesterday','no equivelant'),
(N'きょう','Today','no equivelant'),
(N'あした','Tomorrow','no equivelant'),
(N'げつようび','Monday','no equivelant'),
(N'かようび','Tuesday','no equivelant'),
(N'すいようび','Wednesday','no equivelant'),
(N'もくようび','Thursday','no equivelant'),
(N'きんようび','Friday','no equivelant'),
(N'どようび','Saturday','no equivelant'),
(N'にちようび','Sunday','no equivelant'),
(N'へいじつ','Weekday','no equivelant'),
(N'しゅうまつ','Weekend','no equivelant');

insert into verb_groups(verb_hira,verb_eng,verb_group) values
(N'たべる','To eat',1),
(N'ねる','To sleep, go to bed',1),
(N'みる','To see, look at',1),
(N'おきる','To get up',1),
(N'おりる','To get off',1),
(N'しんじる','To believe',1),
(N'あける','To open',1),
(N'あげる','To give',1),
(N'でる','To go out',1),
(N'よむ','To Read',2),
(N'きく','To Listen, To hear',2),
(N'いく','To Go',2),
(N'かう','To Buy',2),
(N'のむ','To Drink',2),
(N'はなす','To Speak',2),
(N'かく','To Write',2),
(N'まつ','To Wait',2),
(N'はいる','To Enter',2),
(N'はしる','To Run',2),
(N'いる','To Need',2),
(N'かえる','To Return',2),
(N'かぎる','To Limit',2),
(N'きる','To Cut',2),
(N'しゃべる','To Chatter',2),
(N'しる','To Know',2),
(N'あう','To Meet',2),
(N'くる','To Come',3),
(N'する','To Do',3),
(N'べんきょうする','To Study',3),
(N'りょこうする','To Travel',3),
(N'ゆしゅつする','To Export',3),
(N'だんすする','To Dance',3),
(N'しゃんぷうする','To Shampoo',3),
(N'しょうかいする','To Introduce',3);

insert into particles(particle_hira, particle_eng) Values
(N'で','Grp1 particle for action place'),
(N'を','Grp1 particle for direct object'),
(N'か','Grp3 particle for questions'),
(N'は','Grp2 particle for topic'),
(N'へ','Grp1 particle for direction'),
(N'と','Grp1 particle for noun+noun'),
(N'も','Grp2 particle for noun+verb, positive and negative'),
(N'が','Grp1 particle for action');

insert into conjugation(conjugation_hira, conjugation_eng) values
(N'ます','(polite form positive, present)'),
(N'ません','(polite form negative, present)'),
(N'ました','(polite form positive, past)'),
(N'ませんでした','(polite form past, negative)');

insert into patterns(pattern_design, pattern_example) values
(N'~が´+~は　(illegal combination - use は)',N'ナルト + が + ダンさん + は + あいます。 ~ ナルト + ｘ + だんさん + は + あいます。'),
(N'~が+~も　(illegal combination - use も)',N'アリス + が + も + ごはん + を + たべます ~ アリス + ｘ + も + ごはん + を + たべます。'),
(N'~を+~は　(illegal combination - use は)',N'no idea...'),
(N'time+object+を+verb',N'あした + しんぶん + を + よみます。'),
(N'(person)+noun+は+verb',N'(ルインさん) + こうひい + は + たべます。'),
(N'place+へ+verb.',N'りゅ + か + くせいかいかん + へ + いきます。'),
(N'person+は+verb',N'モモさん + は + べんきょうしません。'),
(N'person+が+verb',N'サクラさん + が + おきます。'),
(N'noun+と+noun+を+verb.',N'さらだ + と + ごはん + を + たべます。'),
(N'noun+は+だれ+が+verb',N'こうひい + は + だれ + が + みましたか。'),
(N'person+は+time+place+へ+verb',N'アリスさん + は + きょう + だいがく + へ + かえります。'),
(N'time+person+は+object+を+verb',N'きのう + サスケさん + は + おんがく + を + かえりませんでした。'),
(N'person+noun+は+verb',N'アリスさん + ごはん + は + たべます。'),
(N'person+は+なに+を+verb+か',N'ルインさん + は + なに+を + かきます + か。'),
(N'person+は+どこ+へ+verb+か',N'ユリさん + は + どこ + へ + りょこうします + か。'),
(N'person+は+time+object+を+verb',N'サクラさん + は + きょう + ごはん + を + たべます。'),
(N'person+は+place+で+object+を+verb',N'だんさん + は + だいがく + で + さかなふらいでいしょく + を + たべません。'),
(N'person+は+object+を+verb。person/object+も+same verb.',N'ダンさん + は + かんじ + を + べんきょうします。　ひらがな + も + べんきょうします。'),
(N'person+は+place+へ+verb。 place+へも+same verb.',N'だんさん + は + としょかん + へ + いきます。 きょうしつ + へ + も + いきます。'),
(N'person+は+object+を+verb。 person/object+は+contra verb.',N'ダンさん + は + ひらがな + を + かきます。 かたあな + は + かきません。'),
(N'person+は+place+へ+verb。 place+へは+contra verb.',N'ダンさん + は + としょうかん + へ + かえりません。 りょかくせいかいかん + は + います。');

insert into special(special_hira, special_eng) values
(N'だれと','With who?'),
(N'だれが','Who does?'),
(N'なにを','What object?'),
(N'どこへ','To where?');

insert into kanji(kanji_kanji, kanji_eng) values
(N'一','ichi , one'),
(N'二','ni, two)'),
(N'三','san, three'),
(N'四','shi, four'),
(N'五','go, five'),
(N'六','roku, six'),
(N'七','shichi, seven'),
(N'八','hachi, eight'),
(N'九','kyuu, nine'),
(N'十','jyuu, ten'),
(N'百','hyaku, 100'),
(N'千','sen, thousand'),
(N'万','man, ten thousand'),
(N'円','yen, japan currency'),
(N'年','nen, year');