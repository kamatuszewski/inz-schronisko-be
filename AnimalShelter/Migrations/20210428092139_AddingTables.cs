using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class AddingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    IdMedicine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicine_PK", x => x.IdMedicine);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_PK", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Role_PK", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    IdSpecialty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Specialty_PK", x => x.IdSpecialty);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    IdSpecies = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Species_PK", x => x.IdSpecies);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Status_PK", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    IdTreatment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Treatment_PK", x => x.IdTreatment);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Admin_PK", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "Person_Admin",
                        column: x => x.IdAdmin,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adopter",
                columns: table => new
                {
                    IdAdopter = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Adopter_PK", x => x.IdAdopter);
                    table.ForeignKey(
                        name: "Person_Adopter",
                        column: x => x.IdAdopter,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    IdDirector = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Director_PK", x => x.IdDirector);
                    table.ForeignKey(
                        name: "Person_Director",
                        column: x => x.IdDirector,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_PK", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "Person_Emplyee",
                        column: x => x.IdEmployee,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(type: "int", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendance = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Volunteer_PK", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "Person_Volunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrantedRole",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GrantedRoles_PK", x => new { x.IdPerson, x.IdRole });
                    table.ForeignKey(
                        name: "GrantedRole_Person",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GrantedRole_Role",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterNumber = table.Column<int>(type: "int", nullable: false),
                    ChipNumber = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoundPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdSpecies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Animal_PK", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "Animal_Species",
                        column: x => x.IdSpecies,
                        principalTable: "Species",
                        principalColumn: "IdSpecies",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Animal_Status",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdoptionOfficeWorker",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdSpecies = table.Column<int>(type: "int", nullable: false),
                    AssignedSpecies = table.Column<int>(type: "int", nullable: false),
                    SpeciesIdSpecies = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AOWorker_PK", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "Employee_AOWorker",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdoptionOfficeWorker_Species_SpeciesIdSpecies",
                        column: x => x.SpeciesIdSpecies,
                        principalTable: "Species",
                        principalColumn: "IdSpecies",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vet",
                columns: table => new
                {
                    IdVet = table.Column<int>(type: "int", nullable: false),
                    PWZNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Vet_PK", x => x.IdVet);
                    table.ForeignKey(
                        name: "Employee_Vet",
                        column: x => x.IdVet,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adoption",
                columns: table => new
                {
                    IdAdoption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsItOwnerPickUp = table.Column<bool>(type: "bit", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    IdAdopter = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Adoption_PK", x => x.IdAdoption);
                    table.ForeignKey(
                        name: "Adoption_Adopter",
                        column: x => x.IdAdopter,
                        principalTable: "Adopter",
                        principalColumn: "IdAdopter",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Adoption_Animal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Adoption_AOWorkerr",
                        column: x => x.IdEmployee,
                        principalTable: "AdoptionOfficeWorker",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vet_Specialty",
                columns: table => new
                {
                    IdVet = table.Column<int>(type: "int", nullable: false),
                    IdSpecialty = table.Column<int>(type: "int", nullable: false),
                    ObtainingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Vet_Specialty_PK", x => new { x.IdVet, x.IdSpecialty });
                    table.ForeignKey(
                        name: "Vet_Specialty_Specialty",
                        column: x => x.IdSpecialty,
                        principalTable: "Specialty",
                        principalColumn: "IdSpecialty",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vet_Specialty_Vet",
                        column: x => x.IdVet,
                        principalTable: "Vet",
                        principalColumn: "IdVet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VetVisit",
                columns: table => new
                {
                    IdVisit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVet = table.Column<int>(type: "int", nullable: false),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    VisitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("VetVisit_PK", x => x.IdVisit);
                    table.ForeignKey(
                        name: "VetVisit_Animal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VetVisit_Vet",
                        column: x => x.IdVet,
                        principalTable: "Vet",
                        principalColumn: "IdVet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformedTreatment",
                columns: table => new
                {
                    IdTreatment = table.Column<int>(type: "int", nullable: false),
                    IdVisit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PerformedTreatment_PK", x => new { x.IdTreatment, x.IdVisit });
                    table.ForeignKey(
                        name: "PerformedTreatment_Treatment",
                        column: x => x.IdTreatment,
                        principalTable: "Treatment",
                        principalColumn: "IdTreatment",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PerformedTreatment_Visit",
                        column: x => x.IdVisit,
                        principalTable: "VetVisit",
                        principalColumn: "IdVisit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedMedicine",
                columns: table => new
                {
                    IdMedicine = table.Column<int>(type: "int", nullable: false),
                    IdVisit = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrescribedMedicine_PK", x => new { x.IdMedicine, x.IdVisit });
                    table.ForeignKey(
                        name: "PrescribedMedicine_Medicine",
                        column: x => x.IdMedicine,
                        principalTable: "Medicine",
                        principalColumn: "IdMedicine",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PrescribedMedicine_Visit",
                        column: x => x.IdVisit,
                        principalTable: "VetVisit",
                        principalColumn: "IdVisit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_IdAdopter",
                table: "Adoption",
                column: "IdAdopter");

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_IdAnimal",
                table: "Adoption",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_IdEmployee",
                table: "Adoption",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionOfficeWorker_SpeciesIdSpecies",
                table: "AdoptionOfficeWorker",
                column: "SpeciesIdSpecies");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_IdSpecies",
                table: "Animal",
                column: "IdSpecies");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_IdStatus",
                table: "Animal",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_GrantedRole_IdRole",
                table: "GrantedRole",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedTreatment_IdVisit",
                table: "PerformedTreatment",
                column: "IdVisit");

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicine_IdVisit",
                table: "PrescribedMedicine",
                column: "IdVisit");

            migrationBuilder.CreateIndex(
                name: "IX_Vet_Specialty_IdSpecialty",
                table: "Vet_Specialty",
                column: "IdSpecialty");

            migrationBuilder.CreateIndex(
                name: "IX_VetVisit_IdAnimal",
                table: "VetVisit",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_VetVisit_IdVet",
                table: "VetVisit",
                column: "IdVet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Adoption");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "GrantedRole");

            migrationBuilder.DropTable(
                name: "PerformedTreatment");

            migrationBuilder.DropTable(
                name: "PrescribedMedicine");

            migrationBuilder.DropTable(
                name: "Vet_Specialty");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Adopter");

            migrationBuilder.DropTable(
                name: "AdoptionOfficeWorker");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "VetVisit");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Vet");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
