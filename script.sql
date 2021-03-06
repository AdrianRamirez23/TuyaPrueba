USE [Tuya]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [varchar](13) NOT NULL,
	[CorreoElectronico] [varchar](150) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Contacto1] [varchar](11) NOT NULL,
	[Contacto2] [varchar](7) NULL,
	[Ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[IdDetail] [int] IDENTITY(1,1) NOT NULL,
	[IdDetalleFactura] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[IdDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [varchar](13) NOT NULL,
	[IdDetalleFactura] [int] NOT NULL,
	[Subtotal] [float] NOT NULL,
	[Impuestos] [float] NOT NULL,
	[Flete] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[FechaFactura] [date] NOT NULL,
	[UsuarioFactura] [int] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC,
	[IdCliente] ASC,
	[IdDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoPedido] [int] NOT NULL,
	[IdFactura] [int] NOT NULL,
	[IdDetalleFactura] [int] NOT NULL,
	[FechaDespacho] [date] NOT NULL,
	[FechaReparto] [date] NULL,
	[FechaEntrega] [date] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC,
	[IdTipoPedido] ASC,
	[IdFactura] ASC,
	[IdDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[PLU] [varchar](5) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdStock] [int] NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[PLU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[IdStock] [int] IDENTITY(1,1) NOT NULL,
	[StockCEDI] [int] NOT NULL,
	[StockVMI] [int] NOT NULL,
	[StockMKP] [int] NOT NULL,
	[StockTienda] [int] NOT NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[IdStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposPedidos]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposPedidos](
	[IdTipoPedido] [int] IDENTITY(1,1) NOT NULL,
	[TiposPedido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposPedidos] PRIMARY KEY CLUSTERED 
(
	[IdTipoPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposUsuarios]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposUsuarios](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuarios] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TiposUsuarios] PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 7/19/2021 3:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CorreoElectronico] [varchar](150) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Contacto1] [varchar](11) NOT NULL,
	[Contacto2] [varchar](7) NULL,
	[IdTipoUsuario] [int] NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [DescripcionCategoria]) VALUES (1, N'Electrodomesticos')
INSERT [dbo].[Categorias] ([IdCategoria], [DescripcionCategoria]) VALUES (2, N'Hogar')
INSERT [dbo].[Categorias] ([IdCategoria], [DescripcionCategoria]) VALUES (3, N'Ferretería')
INSERT [dbo].[Categorias] ([IdCategoria], [DescripcionCategoria]) VALUES (4, N'Hombres')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
INSERT [dbo].[Clientes] ([IdCliente], [CorreoElectronico], [Nombres], [Apellidos], [Direccion], [Contacto1], [Contacto2], [Ciudad]) VALUES (N'1036598444', N'adrian.ramirez23@hotmail.com', N'Adrian Esteban', N'Ramirez Jimenez', N'Calle 79 sur # 55 15', N'3014881243', N'5581946', N'La Estrella')
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

INSERT [dbo].[DetalleFactura] ([IdDetail], [IdDetalleFactura], [IdProducto], [Cantidad]) VALUES (1, 1, 1, 4)
INSERT [dbo].[DetalleFactura] ([IdDetail], [IdDetalleFactura], [IdProducto], [Cantidad]) VALUES (2, 1, 2, 3)
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([IdFactura], [IdCliente], [IdDetalleFactura], [Subtotal], [Impuestos], [Flete], [Total], [FechaFactura], [UsuarioFactura]) VALUES (1, N'1036598444', 1, 7500000, 1425000, 5000, 6080000, CAST(N'2021-07-19' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([IdPedido], [IdTipoPedido], [IdFactura], [IdDetalleFactura], [FechaDespacho], [FechaReparto], [FechaEntrega]) VALUES (1, 4, 1, 1, CAST(N'2021-07-21' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [PLU], [IdCategoria], [IdStock], [Precio]) VALUES (1, N'TV Samsung', N'10001', 1, 1, 1500000)
INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [PLU], [IdCategoria], [IdStock], [Precio]) VALUES (2, N'Cortinas Altas', N'10002', 2, 2, 500000)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Stocks] ON 

INSERT [dbo].[Stocks] ([IdStock], [StockCEDI], [StockVMI], [StockMKP], [StockTienda]) VALUES (1, 500, 400, 300, 200)
INSERT [dbo].[Stocks] ([IdStock], [StockCEDI], [StockVMI], [StockMKP], [StockTienda]) VALUES (2, 500, 300, 200, 400)
SET IDENTITY_INSERT [dbo].[Stocks] OFF
SET IDENTITY_INSERT [dbo].[TiposPedidos] ON 

INSERT [dbo].[TiposPedidos] ([IdTipoPedido], [TiposPedido]) VALUES (1, N'En Sitio')
INSERT [dbo].[TiposPedidos] ([IdTipoPedido], [TiposPedido]) VALUES (2, N'Virtual Propio')
INSERT [dbo].[TiposPedidos] ([IdTipoPedido], [TiposPedido]) VALUES (3, N'Virtual MKP')
INSERT [dbo].[TiposPedidos] ([IdTipoPedido], [TiposPedido]) VALUES (4, N'Compra y Recoge')
SET IDENTITY_INSERT [dbo].[TiposPedidos] OFF
SET IDENTITY_INSERT [dbo].[TiposUsuarios] ON 

INSERT [dbo].[TiposUsuarios] ([idTipoUsuario], [TipoUsuarios]) VALUES (1, N'Admin')
INSERT [dbo].[TiposUsuarios] ([idTipoUsuario], [TipoUsuarios]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[TiposUsuarios] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [CorreoElectronico], [Nombres], [Apellidos], [Direccion], [Contacto1], [Contacto2], [IdTipoUsuario], [Ciudad]) VALUES (1, N'aramirez@correo.com', N'Andres', N'Ramirez', N'Calle 75 sur 53 30', N'3014881243', N'5552233', 1, N'Itagui')
INSERT [dbo].[Usuarios] ([IdUsuario], [CorreoElectronico], [Nombres], [Apellidos], [Direccion], [Contacto1], [Contacto2], [IdTipoUsuario], [Ciudad]) VALUES (2, N'nhiguita@correo.com', N'Natalia', N'Higuita', N'Calle 79 sur 55 15', N'3192341346', N'5552244', 2, N'Medellín')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Index [IX_Categorias]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Categorias] ADD  CONSTRAINT [IX_Categorias] UNIQUE NONCLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clientes]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [IX_Clientes] UNIQUE NONCLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetalleFactura]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[DetalleFactura] ADD  CONSTRAINT [IX_DetalleFactura] UNIQUE NONCLUSTERED 
(
	[IdDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Facturas]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Facturas] ADD  CONSTRAINT [IX_Facturas] UNIQUE NONCLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedidos]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [IX_Pedidos] UNIQUE NONCLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Productos]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [IX_Productos] UNIQUE NONCLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stocks]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Stocks] ADD  CONSTRAINT [IX_Stocks] UNIQUE NONCLUSTERED 
(
	[IdStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TiposPedidos]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[TiposPedidos] ADD  CONSTRAINT [IX_TiposPedidos] UNIQUE NONCLUSTERED 
(
	[IdTipoPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TiposUsuarios]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[TiposUsuarios] ADD  CONSTRAINT [IX_TiposUsuarios] UNIQUE NONCLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios]    Script Date: 7/19/2021 3:16:13 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Productos]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Usuarios] FOREIGN KEY([UsuarioFactura])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Usuarios]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Facturas] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Facturas] ([IdFactura])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Facturas]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_TiposPedidos] FOREIGN KEY([IdTipoPedido])
REFERENCES [dbo].[TiposPedidos] ([IdTipoPedido])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_TiposPedidos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias1] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias1]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Stocks] FOREIGN KEY([IdStock])
REFERENCES [dbo].[Stocks] ([IdStock])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Stocks]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TiposUsuarios] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[TiposUsuarios] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TiposUsuarios]
GO
