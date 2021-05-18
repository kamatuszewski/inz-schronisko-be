using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Repository.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionOfficeWorker_Species_SpeciesIdSpecies",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropForeignKey(
                name: "Person_Emplyee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionOfficeWorker_SpeciesIdSpecies",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropColumn(
                name: "SpeciesIdSpecies",
                table: "AdoptionOfficeWorker");

            migrationBuilder.RenameColumn(
                name: "IdVolunteer",
                table: "Volunteer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdVisit",
                table: "VetVisit",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdVet",
                table: "Vet",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTreatment",
                table: "Treatment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "Status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdSpecies",
                table: "Species",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdSpecialty",
                table: "Specialty",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdMedicine",
                table: "PrescribedMedicine",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPerson",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTreatment",
                table: "PerformedTreatment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdMedicine",
                table: "Medicine",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdEmployee",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdDirector",
                table: "Director",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAnimal",
                table: "Animal",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssignedSpecies",
                table: "AdoptionOfficeWorker",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAdoption",
                table: "Adoption",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAdopter",
                table: "Adopter",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdAdmin",
                table: "Admin",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Volunteer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Volunteer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Volunteer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "VetVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VetVisit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "VetVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Vet_Specialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Vet_Specialty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vet_Specialty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Vet_Specialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Vet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Vet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Treatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Treatment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Treatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Status",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Species",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Species",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Specialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Specialty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Specialty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "PrescribedMedicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PrescribedMedicine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "PrescribedMedicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "PerformedTreatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PerformedTreatment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "PerformedTreatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Medicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Medicine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Medicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "GrantedRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GrantedRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GrantedRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "GrantedRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Director",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Director",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Director",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Animal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Animal",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Animal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "AdoptionOfficeWorker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AdoptionOfficeWorker",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "AdoptionOfficeWorker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Adoption",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Adoption",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Adoption",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Adopter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Adopter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Adopter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Admin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Admin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionOfficeWorker_IdSpecies",
                table: "AdoptionOfficeWorker",
                column: "IdSpecies");

            migrationBuilder.AddForeignKey(
                name: "Employee_Species",
                table: "AdoptionOfficeWorker",
                column: "IdSpecies",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Person_Emplyee",
                table: "Employee",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Employee_Species",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropForeignKey(
                name: "Person_Emplyee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PersonId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionOfficeWorker_IdSpecies",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "VetVisit");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VetVisit");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "VetVisit");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Vet_Specialty");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Vet_Specialty");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vet_Specialty");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Vet_Specialty");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Vet");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vet");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Vet");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "PrescribedMedicine");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PrescribedMedicine");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "PrescribedMedicine");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "PerformedTreatment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PerformedTreatment");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "PerformedTreatment");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "GrantedRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GrantedRole");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GrantedRole");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "GrantedRole");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "AdoptionOfficeWorker");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Adopter");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Adopter");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Adopter");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Volunteer",
                newName: "IdVolunteer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VetVisit",
                newName: "IdVisit");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vet",
                newName: "IdVet");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Treatment",
                newName: "IdTreatment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Status",
                newName: "IdStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Species",
                newName: "IdSpecies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialty",
                newName: "IdSpecialty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Role",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PrescribedMedicine",
                newName: "IdMedicine");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "IdPerson");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PerformedTreatment",
                newName: "IdTreatment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Medicine",
                newName: "IdMedicine");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "IdEmployee");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Director",
                newName: "IdDirector");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animal",
                newName: "IdAnimal");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AdoptionOfficeWorker",
                newName: "AssignedSpecies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Adoption",
                newName: "IdAdoption");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Adopter",
                newName: "IdAdopter");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "IdAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "IdEmployee",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesIdSpecies",
                table: "AdoptionOfficeWorker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionOfficeWorker_SpeciesIdSpecies",
                table: "AdoptionOfficeWorker",
                column: "SpeciesIdSpecies");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionOfficeWorker_Species_SpeciesIdSpecies",
                table: "AdoptionOfficeWorker",
                column: "SpeciesIdSpecies",
                principalTable: "Species",
                principalColumn: "IdSpecies",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Person_Emplyee",
                table: "Employee",
                column: "IdEmployee",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
