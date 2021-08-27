using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Data.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    EpisodeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    OpeningCrawl = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RotationPeriod = table.Column<string>(nullable: true),
                    OribitalPeriod = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    Climate = table.Column<string>(nullable: true),
                    Gravity = table.Column<string>(nullable: true),
                    Terrain = table.Column<string>(nullable: true),
                    SurfaceWater = table.Column<string>(nullable: true),
                    Population = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CostInCredits = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    MaximumAtmosphericSpeed = table.Column<string>(nullable: true),
                    Crew = table.Column<string>(nullable: true),
                    Passengers = table.Column<string>(nullable: true),
                    CargoCapacity = table.Column<string>(nullable: true),
                    Consumables = table.Column<string>(nullable: true),
                    StarshipClass = table.Column<string>(nullable: true),
                    HyperdriveRating = table.Column<string>(nullable: true),
                    Mglt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CostInCredits = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    MaximumAtmosphericSpeed = table.Column<string>(nullable: true),
                    Crew = table.Column<string>(nullable: true),
                    Passengers = table.Column<string>(nullable: true),
                    CargoCapacity = table.Column<string>(nullable: true),
                    Consumables = table.Column<string>(nullable: true),
                    VehicleClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Mass = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    BirthYear = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    HomeWorldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlanet",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    PlanetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanet", x => new { x.FilmId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhotoBytes = table.Column<byte[]>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Edited = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    AverageHeight = table.Column<string>(nullable: true),
                    SkinColors = table.Column<string>(nullable: true),
                    HairColors = table.Column<string>(nullable: true),
                    EyeColors = table.Column<string>(nullable: true),
                    AverageLifespan = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    HomeWorldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmStarship",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    StarshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStarship", x => new { x.FilmId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_FilmStarship_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmStarship_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmVehicle",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicle", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPlanet",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    PlanetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPlanet", x => new { x.CharacterId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_CharacterPlanet_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPlanet_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterStarship",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    StarshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStarship", x => new { x.CharacterId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_CharacterStarship_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStarship_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterVehicle",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterVehicle", x => new { x.CharacterId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_CharacterVehicle_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCharacter",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCharacter", x => new { x.FilmId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCharacter_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpecies",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    SpeciesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpecies", x => new { x.CharacterId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_CharacterSpecies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmSpecies",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    SpeciesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSpecies", x => new { x.FilmId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPlanet_PlanetId",
                table: "CharacterPlanet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HomeWorldId",
                table: "Characters",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpecies_SpeciesId",
                table: "CharacterSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStarship_StarshipId",
                table: "CharacterStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterVehicle_VehicleId",
                table: "CharacterVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCharacter_CharacterId",
                table: "FilmCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_PlanetId",
                table: "FilmPlanet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSpecies_SpeciesId",
                table: "FilmSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarship_StarshipId",
                table: "FilmStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_VehicleId",
                table: "FilmVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_HomeWorldId",
                table: "Species",
                column: "HomeWorldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterPlanet");

            migrationBuilder.DropTable(
                name: "CharacterSpecies");

            migrationBuilder.DropTable(
                name: "CharacterStarship");

            migrationBuilder.DropTable(
                name: "CharacterVehicle");

            migrationBuilder.DropTable(
                name: "FilmCharacter");

            migrationBuilder.DropTable(
                name: "FilmPlanet");

            migrationBuilder.DropTable(
                name: "FilmSpecies");

            migrationBuilder.DropTable(
                name: "FilmStarship");

            migrationBuilder.DropTable(
                name: "FilmVehicle");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
