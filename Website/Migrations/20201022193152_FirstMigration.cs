using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Website.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayarlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eposta = table.Column<string>(nullable: true),
                    FabrikaAdres = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    OfisAdres = table.Column<string>(nullable: true),
                    SiteAciklama = table.Column<string>(nullable: true),
                    SiteBaslik = table.Column<string>(nullable: true),
                    SiteEtiket = table.Column<string>(nullable: true),
                    SiteLogo = table.Column<string>(nullable: true),
                    SiteSlogan = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(nullable: false),
                    Dil = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    ResimYolu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliderlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama1 = table.Column<string>(nullable: true),
                    Aciklama2 = table.Column<string>(nullable: true),
                    Aciklama3 = table.Column<string>(nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    Resim = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliderlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SSSler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cevap = table.Column<string>(nullable: false),
                    Dil = table.Column<string>(nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    Soru = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSSler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrunGruplar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama = table.Column<string>(nullable: true),
                    Adi = table.Column<string>(nullable: false),
                    Dil = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunGruplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videolar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(nullable: false),
                    Dil = table.Column<string>(nullable: false),
                    Icerik = table.Column<string>(nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    Yazar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloglar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Baslik = table.Column<string>(nullable: false),
                    Dil = table.Column<string>(nullable: false),
                    Icerik = table.Column<string>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    OneCikanGorsel = table.Column<string>(nullable: true),
                    Yazar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloglar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloglar_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama = table.Column<string>(nullable: true),
                    Adi = table.Column<string>(nullable: true),
                    Agirligi = table.Column<double>(nullable: false),
                    Boyu = table.Column<double>(nullable: false),
                    Brosur = table.Column<string>(nullable: true),
                    Capi = table.Column<double>(nullable: false),
                    Dil = table.Column<string>(nullable: false),
                    DolumHacimi = table.Column<int>(nullable: false),
                    KafaTipi = table.Column<string>(nullable: true),
                    Kodu = table.Column<string>(nullable: true),
                    OneCikanGorsel = table.Column<string>(nullable: true),
                    PaletAgirligi = table.Column<int>(nullable: false),
                    PaletIcAdedi = table.Column<int>(nullable: false),
                    PaletSiraSayisi = table.Column<int>(nullable: false),
                    PaletYuksekligi = table.Column<int>(nullable: false),
                    SilmeHacimi = table.Column<int>(nullable: false),
                    SiraNo = table.Column<int>(nullable: false),
                    TavaUrunAdedi = table.Column<int>(nullable: false),
                    UrunGrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_UrunGruplar_UrunGrupId",
                        column: x => x.UrunGrupId,
                        principalTable: "UrunGruplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etiketler",
                columns: table => new
                {
                    EtiketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: true),
                    Dil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiketler", x => x.EtiketId);
                    table.ForeignKey(
                        name: "FK_Etiketler_Bloglar_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Bloglar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrunResimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    UrunId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunResimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunResimler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloglar_KategoriId",
                table: "Bloglar",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Etiketler_BlogId",
                table: "Etiketler",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_UrunGrupId",
                table: "Urunler",
                column: "UrunGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunResimler_UrunId",
                table: "UrunResimler",
                column: "UrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayarlar");

            migrationBuilder.DropTable(
                name: "Etiketler");

            migrationBuilder.DropTable(
                name: "Resimler");

            migrationBuilder.DropTable(
                name: "Sliderlar");

            migrationBuilder.DropTable(
                name: "SSSler");

            migrationBuilder.DropTable(
                name: "UrunResimler");

            migrationBuilder.DropTable(
                name: "Videolar");

            migrationBuilder.DropTable(
                name: "Yazilar");

            migrationBuilder.DropTable(
                name: "Bloglar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "UrunGruplar");
        }
    }
}
