USE [hungrypizzadb]
GO

/****** Object:  Table [dbo].[Pizzas]    Script Date: 13/09/2020 6:58:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzas](
	[IdPizza] [int] IDENTITY(1,1) NOT NULL,
	[Sabor] [varchar](100) NOT NULL,
	[Valor] [decimal](5,2) NOT NULL,
CONSTRAINT [PK_Pizzas] PRIMARY KEY CLUSTERED 
(
[IdPizza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 13/09/2020 6:58:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[ValorTotal] [decimal](5,2) NOT NULL,
        [IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PedidoDetalhe]    Script Date: 13/09/2020 6:58:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetalhe](
	[IdPedidoDetalhe] [int] IDENTITY(1,1) NOT NULL,
        [IdPedido] [int] NOT NULL,
	[NomePizza1] [varchar](100) NOT NULL,
	[NomePizza2] [varchar](100) NULL,
	[ValorPizza1] [decimal](5,2) NOT NULL,
	[ValorPizza2] [decimal](5,2) NULL,
 CONSTRAINT [PK_PedidoDetalhe] PRIMARY KEY CLUSTERED 
(
[IdPedidoDetalhe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 13/09/2020 6:58:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Numero] [int] NOT NULL,
	[Complemento] [varchar](100) NULL,
	[Cep] [varchar](9) NOT NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Telefone] [varchar](14) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](20) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Pizzas] ON 
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (1, N'3 Queijos', 50.00)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (2, N'Frango com requeijão', 59.99)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (3, N'Mussarela', 42.50)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (4, N'Calabresa', 42.50)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (5, N'Pepperoni', 55.00)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (6, N'Portuguesa', 45.00)
INSERT [dbo].[Pizzas] ([IdPizza], [Sabor], [Valor]) VALUES (7, N'Veggie', 59.99)
SET IDENTITY_INSERT [dbo].[Pizzas] OFF

SET IDENTITY_INSERT [dbo].[Clientes] ON 
INSERT [dbo].[Clientes] ([IdCliente], [Nome], [Endereco], [Numero], [Complemento], [Cep], [Bairro], [Cidade], [Telefone], [Email], [Senha]) 
VALUES (1, N'Administrador', N'Rua do admin', 123, null, N'01234-567', N'Bairro do admin', N'Cidade do admin', N'(11)12345-6789', N'hungrypizza@ehungrypizza.com.br', N'123456')
SET IDENTITY_INSERT [dbo].[Clientes] OFF

ALTER TABLE [dbo].[Pedidos] WITH NOCHECK ADD CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO

ALTER TABLE [dbo].[PedidoDetalhe] WITH NOCHECK ADD CONSTRAINT [FK_Pedido_Detalhe] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedidos] ([IdPedido])
GO
ALTER TABLE [dbo].[PedidoDetalhe] CHECK CONSTRAINT [FK_Pedido_Detalhe]
GO

