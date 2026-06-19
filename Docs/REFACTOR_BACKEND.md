# VPGameWeb Backend Refactor Task

## Goal
Refactor the current ASP.NET Core project into a clean layered architecture used in production projects.

---

## Target Architecture

Controller → Service → DbContext → SQLite

NO direct LINQ queries in Controllers.

---

## Rules

### 1. Controllers
- Only handle HTTP requests
- No LINQ
- No business logic
- Must call Service only

---

### 2. Services
Create service layer for:

- CharacterService
- SkillService
- MonsterService
- ItemService

Each service handles:
- Query all
- Query by id
- Filter queries

---

### 3. DTO Requirement
Do NOT return EF Entities directly.

Create DTOs for:
- Character
- Skill
- Monster
- Item

---

### 4. API Routes

Standardize routes:

/api/characters
/api/characters/{id}

/api/skills
/api/monsters
/api/items

---

### 5. Database Rules
- DbInitializer is ONLY for development seed data
- Do not modify runtime logic based on it

---

### 6. Must Fix

- Remove circular reference workaround (IgnoreCycles) after DTO is implemented
- Remove test/debug endpoints like race-count
- Ensure all queries go through Service layer

---

### 7. Output Requirement

After refactor:
- No duplicated LINQ in controllers
- All APIs use Service layer
- DTOs used in responses
- Project compiles successfully