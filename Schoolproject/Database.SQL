DROP TABLE IF EXISTS "public"."kha_student";
DROP TABLE IF EXISTS "public"."kha_course";
CREATE TABLE "public"."kha_student" ( 
  "id" SERIAL,
  "first_name" VARCHAR(50) NULL,
  "last_name" VARCHAR(50) NULL,
  "email" VARCHAR(50) NULL,
  "age" INTEGER NULL,
  "password" INTEGER NULL,
  CONSTRAINT "kha_student_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."kha_course" ( 
  "id" SERIAL,
  "name" VARCHAR(50) NULL,
  "points" INTEGER NULL,
  "start_date" DATE NULL,
  "end_date" DATE NULL,
  CONSTRAINT "undefined" PRIMARY KEY ("id")
);
TRUNCATE TABLE "public"."kha_student";
TRUNCATE TABLE "public"."kha_course";
ALTER TABLE "public"."kha_student" DISABLE TRIGGER ALL;
ALTER TABLE "public"."kha_course" DISABLE TRIGGER ALL;
INSERT INTO "public"."kha_student" ("first_name", "last_name", "email", "age", "password") VALUES ('MK', 'HOSSAIN', 'mk@chas.se', 28, 987);
INSERT INTO "public"."kha_student" ("first_name", "last_name", "email", "age", "password") VALUES ('MONIRUL', 'ISLAM', 'monirul@chas.se', 29, 987);
INSERT INTO "public"."kha_student" ("first_name", "last_name", "email", "age", "password") VALUES ('SHOBUZ', 'HASAN', 'shobuz@chas.se', 22, 123456);
INSERT INTO "public"."kha_course" ("name", "points", "start_date", "end_date") VALUES ('HTML', 410, '2021-01-20', '2024-02-15');
INSERT INTO "public"."kha_course" ("name", "points", "start_date", "end_date") VALUES ('C#', 200, '2022-10-20', '2023-02-15');
INSERT INTO "public"."kha_course" ("name", "points", "start_date", "end_date") VALUES ('BACKEND', 200, '2022-01-15', '2023-06-30');
ALTER TABLE "public"."kha_student" ENABLE TRIGGER ALL;
ALTER TABLE "public"."kha_course" ENABLE TRIGGER ALL;
