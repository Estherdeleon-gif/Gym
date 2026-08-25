--
-- PostgreSQL database dump
--

\restrict htLIjReWPLMQQFNMkarEsg8V7R4k83BtvsXaFAxLFFxQcLlE64NfqWCbVwDUCRO

-- Dumped from database version 17.10
-- Dumped by pg_dump version 17.10

-- Started on 2026-08-25 18:07:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 236 (class 1259 OID 16491)
-- Name: Caracteristicas_de_productos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Caracteristicas_de_productos" (
);


ALTER TABLE public."Caracteristicas_de_productos" OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 16462)
-- Name: Clases; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Clases" (
);


ALTER TABLE public."Clases" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16420)
-- Name: Clientes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Clientes" (
);


ALTER TABLE public."Clientes" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16436)
-- Name: Entrenador; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Entrenador" (
);


ALTER TABLE public."Entrenador" OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16476)
-- Name: Horarios; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Horarios" (
);


ALTER TABLE public."Horarios" OWNER TO postgres;

--
-- TOC entry 255 (class 1259 OID 16616)
-- Name: Mantenimiento; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Mantenimiento" (
    id_mantenimiento integer NOT NULL,
    equipo character varying(150) NOT NULL,
    fecha timestamp without time zone NOT NULL,
    tipo character varying(50) NOT NULL,
    descripcion text,
    costo numeric(12,2) DEFAULT 0 NOT NULL,
    estado character varying(50) NOT NULL,
    proximo_mantenimiento timestamp without time zone NOT NULL
);


ALTER TABLE public."Mantenimiento" OWNER TO postgres;

--
-- TOC entry 254 (class 1259 OID 16615)
-- Name: Mantenimiento_id_mantenimiento_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Mantenimiento_id_mantenimiento_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Mantenimiento_id_mantenimiento_seq" OWNER TO postgres;

--
-- TOC entry 5116 (class 0 OID 0)
-- Dependencies: 254
-- Name: Mantenimiento_id_mantenimiento_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Mantenimiento_id_mantenimiento_seq" OWNED BY public."Mantenimiento".id_mantenimiento;


--
-- TOC entry 245 (class 1259 OID 16540)
-- Name: Marcas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Marcas" (
);


ALTER TABLE public."Marcas" OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 16601)
-- Name: Membresia; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Membresia" (
    id_membresia integer NOT NULL,
    id_cliente integer NOT NULL,
    tipo character varying(50) NOT NULL,
    fecha_inicio date NOT NULL,
    fecha_fin date NOT NULL,
    precio numeric(10,2) NOT NULL,
    estado boolean DEFAULT true NOT NULL
);


ALTER TABLE public."Membresia" OWNER TO postgres;

--
-- TOC entry 250 (class 1259 OID 16600)
-- Name: Membresia_id_membresia_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Membresia_id_membresia_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Membresia_id_membresia_seq" OWNER TO postgres;

--
-- TOC entry 5117 (class 0 OID 0)
-- Dependencies: 250
-- Name: Membresia_id_membresia_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Membresia_id_membresia_seq" OWNED BY public."Membresia".id_membresia;


--
-- TOC entry 227 (class 1259 OID 16449)
-- Name: Menbresia; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Menbresia" (
);


ALTER TABLE public."Menbresia" OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 16609)
-- Name: PagoDiario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PagoDiario" (
    id_pago_diario integer NOT NULL,
    precio_entrada numeric(10,2) NOT NULL,
    fecha date NOT NULL,
    metodo_pago character varying(50) NOT NULL,
    concepto character varying(150) NOT NULL,
    estado character varying(30) NOT NULL
);


ALTER TABLE public."PagoDiario" OWNER TO postgres;

--
-- TOC entry 252 (class 1259 OID 16608)
-- Name: PagoDiario_id_pago_diario_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PagoDiario_id_pago_diario_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PagoDiario_id_pago_diario_seq" OWNER TO postgres;

--
-- TOC entry 5118 (class 0 OID 0)
-- Dependencies: 252
-- Name: PagoDiario_id_pago_diario_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PagoDiario_id_pago_diario_seq" OWNED BY public."PagoDiario".id_pago_diario;


--
-- TOC entry 239 (class 1259 OID 16504)
-- Name: Productos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Productos" (
);


ALTER TABLE public."Productos" OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 16526)
-- Name: Proveedores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Proveedores" (
);


ALTER TABLE public."Proveedores" OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 16495)
-- Name: categoriasproductos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categoriasproductos (
    id_categoria integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion text,
    estado boolean DEFAULT true
);


ALTER TABLE public.categoriasproductos OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16494)
-- Name: categoriasproductos_id_categoria_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categoriasproductos_id_categoria_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.categoriasproductos_id_categoria_seq OWNER TO postgres;

--
-- TOC entry 5119 (class 0 OID 0)
-- Dependencies: 237
-- Name: categoriasproductos_id_categoria_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categoriasproductos_id_categoria_seq OWNED BY public.categoriasproductos.id_categoria;


--
-- TOC entry 232 (class 1259 OID 16467)
-- Name: clases; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clases (
    id_clase integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion text,
    cupo_maximo integer NOT NULL,
    estado boolean DEFAULT true
);


ALTER TABLE public.clases OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16466)
-- Name: clases_id_clase_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clases_id_clase_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.clases_id_clase_seq OWNER TO postgres;

--
-- TOC entry 5120 (class 0 OID 0)
-- Dependencies: 231
-- Name: clases_id_clase_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clases_id_clase_seq OWNED BY public.clases.id_clase;


--
-- TOC entry 223 (class 1259 OID 16424)
-- Name: clientes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.clientes (
    id_cliente integer NOT NULL,
    nombre character varying(100) NOT NULL,
    apellido character varying(100) NOT NULL,
    cedula character varying(20) NOT NULL,
    telefono character varying(20) NOT NULL,
    correo character varying(100),
    direccion text,
    fecha_nacimiento date,
    sexo character varying(15),
    foto character varying(255),
    fecha_registro date DEFAULT CURRENT_DATE,
    estado boolean DEFAULT true,
    id_usuario integer
);


ALTER TABLE public.clientes OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16423)
-- Name: clientes_id_cliente_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.clientes_id_cliente_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.clientes_id_cliente_seq OWNER TO postgres;

--
-- TOC entry 5121 (class 0 OID 0)
-- Dependencies: 222
-- Name: clientes_id_cliente_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.clientes_id_cliente_seq OWNED BY public.clientes.id_cliente;


--
-- TOC entry 226 (class 1259 OID 16440)
-- Name: entrenadores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entrenadores (
    id_entrenador integer NOT NULL,
    nombre character varying(100) NOT NULL,
    apellido character varying(100) NOT NULL,
    telefono character varying(20),
    correo character varying(100),
    especialidad character varying(100) NOT NULL,
    horario character varying(100),
    estado boolean DEFAULT true,
    foto character varying(300)
);


ALTER TABLE public.entrenadores OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16439)
-- Name: entrenadores_id_entrenador_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.entrenadores_id_entrenador_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.entrenadores_id_entrenador_seq OWNER TO postgres;

--
-- TOC entry 5122 (class 0 OID 0)
-- Dependencies: 225
-- Name: entrenadores_id_entrenador_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.entrenadores_id_entrenador_seq OWNED BY public.entrenadores.id_entrenador;


--
-- TOC entry 235 (class 1259 OID 16480)
-- Name: horarios; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.horarios (
    id_horario integer NOT NULL,
    id_clase integer NOT NULL,
    dia_semana character varying(20) NOT NULL,
    hora_inicio time without time zone NOT NULL,
    hora_fin time without time zone NOT NULL
);


ALTER TABLE public.horarios OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16479)
-- Name: horarios_id_horario_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.horarios_id_horario_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.horarios_id_horario_seq OWNER TO postgres;

--
-- TOC entry 5123 (class 0 OID 0)
-- Dependencies: 234
-- Name: horarios_id_horario_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.horarios_id_horario_seq OWNED BY public.horarios.id_horario;


--
-- TOC entry 247 (class 1259 OID 16544)
-- Name: marcas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.marcas (
    id_marca integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion text,
    estado boolean DEFAULT true
);


ALTER TABLE public.marcas OWNER TO postgres;

--
-- TOC entry 246 (class 1259 OID 16543)
-- Name: marcas_id_marca_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.marcas_id_marca_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.marcas_id_marca_seq OWNER TO postgres;

--
-- TOC entry 5124 (class 0 OID 0)
-- Dependencies: 246
-- Name: marcas_id_marca_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.marcas_id_marca_seq OWNED BY public.marcas.id_marca;


--
-- TOC entry 248 (class 1259 OID 16561)
-- Name: permisos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.permisos (
    id_permiso integer NOT NULL,
    id_rol integer NOT NULL,
    modulo character varying(50) NOT NULL,
    ver boolean DEFAULT false NOT NULL,
    crear boolean DEFAULT false NOT NULL,
    editar boolean DEFAULT false NOT NULL,
    eliminar boolean DEFAULT false NOT NULL
);


ALTER TABLE public.permisos OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 16565)
-- Name: permisos_id_permiso_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.permisos_id_permiso_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.permisos_id_permiso_seq OWNER TO postgres;

--
-- TOC entry 5125 (class 0 OID 0)
-- Dependencies: 249
-- Name: permisos_id_permiso_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.permisos_id_permiso_seq OWNED BY public.permisos.id_permiso;


--
-- TOC entry 241 (class 1259 OID 16508)
-- Name: productos; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.productos (
    id_producto integer NOT NULL,
    codigo character varying(50) NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion text,
    id_categoria integer NOT NULL,
    precio_compra numeric(10,2) NOT NULL,
    precio_venta numeric(10,2) NOT NULL,
    stock integer DEFAULT 0 NOT NULL,
    stock_minimo integer DEFAULT 0 NOT NULL,
    imagen character varying(255),
    estado boolean DEFAULT true,
    id_marca integer
);


ALTER TABLE public.productos OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 16507)
-- Name: productos_id_producto_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.productos_id_producto_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.productos_id_producto_seq OWNER TO postgres;

--
-- TOC entry 5126 (class 0 OID 0)
-- Dependencies: 240
-- Name: productos_id_producto_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.productos_id_producto_seq OWNED BY public.productos.id_producto;


--
-- TOC entry 244 (class 1259 OID 16530)
-- Name: proveedores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.proveedores (
    id_proveedor integer NOT NULL,
    nombre character varying(100) NOT NULL,
    telefono character varying(20),
    correo character varying(100),
    direccion text,
    estado boolean DEFAULT true,
    empresa character varying(150)
);


ALTER TABLE public.proveedores OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 16529)
-- Name: proveedores_id_proveedor_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.proveedores_id_proveedor_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.proveedores_id_proveedor_seq OWNER TO postgres;

--
-- TOC entry 5127 (class 0 OID 0)
-- Dependencies: 243
-- Name: proveedores_id_proveedor_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.proveedores_id_proveedor_seq OWNED BY public.proveedores.id_proveedor;


--
-- TOC entry 218 (class 1259 OID 16389)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    id_rol integer NOT NULL,
    nombre character varying(50) NOT NULL,
    descripcion character varying(150),
    estado boolean DEFAULT true NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16388)
-- Name: roles_id_rol_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_id_rol_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.roles_id_rol_seq OWNER TO postgres;

--
-- TOC entry 5128 (class 0 OID 0)
-- Dependencies: 217
-- Name: roles_id_rol_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_id_rol_seq OWNED BY public.roles.id_rol;


--
-- TOC entry 229 (class 1259 OID 16453)
-- Name: tiposmembresia; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tiposmembresia (
    id_membresia integer NOT NULL,
    nombre character varying(100) NOT NULL,
    descripcion text,
    duracion_dias integer NOT NULL,
    precio numeric(10,2) NOT NULL,
    estado boolean DEFAULT true
);


ALTER TABLE public.tiposmembresia OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16452)
-- Name: tiposmembresia_id_membresia_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tiposmembresia_id_membresia_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tiposmembresia_id_membresia_seq OWNER TO postgres;

--
-- TOC entry 5129 (class 0 OID 0)
-- Dependencies: 228
-- Name: tiposmembresia_id_membresia_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tiposmembresia_id_membresia_seq OWNED BY public.tiposmembresia.id_membresia;


--
-- TOC entry 220 (class 1259 OID 16398)
-- Name: usuarios; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.usuarios (
    id_usuario integer NOT NULL,
    nombre character varying(100) NOT NULL,
    usuario character varying(50) NOT NULL,
    contrasena character varying(100) NOT NULL,
    id_rol integer NOT NULL,
    estado boolean DEFAULT true NOT NULL
);


ALTER TABLE public.usuarios OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16397)
-- Name: usuarios_id_usuario_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.usuarios_id_usuario_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.usuarios_id_usuario_seq OWNER TO postgres;

--
-- TOC entry 5130 (class 0 OID 0)
-- Dependencies: 219
-- Name: usuarios_id_usuario_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.usuarios_id_usuario_seq OWNED BY public.usuarios.id_usuario;


--
-- TOC entry 4880 (class 2604 OID 16619)
-- Name: Mantenimiento id_mantenimiento; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Mantenimiento" ALTER COLUMN id_mantenimiento SET DEFAULT nextval('public."Mantenimiento_id_mantenimiento_seq"'::regclass);


--
-- TOC entry 4877 (class 2604 OID 16604)
-- Name: Membresia id_membresia; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Membresia" ALTER COLUMN id_membresia SET DEFAULT nextval('public."Membresia_id_membresia_seq"'::regclass);


--
-- TOC entry 4879 (class 2604 OID 16612)
-- Name: PagoDiario id_pago_diario; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PagoDiario" ALTER COLUMN id_pago_diario SET DEFAULT nextval('public."PagoDiario_id_pago_diario_seq"'::regclass);


--
-- TOC entry 4862 (class 2604 OID 16498)
-- Name: categoriasproductos id_categoria; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categoriasproductos ALTER COLUMN id_categoria SET DEFAULT nextval('public.categoriasproductos_id_categoria_seq'::regclass);


--
-- TOC entry 4859 (class 2604 OID 16470)
-- Name: clases id_clase; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clases ALTER COLUMN id_clase SET DEFAULT nextval('public.clases_id_clase_seq'::regclass);


--
-- TOC entry 4852 (class 2604 OID 16427)
-- Name: clientes id_cliente; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clientes ALTER COLUMN id_cliente SET DEFAULT nextval('public.clientes_id_cliente_seq'::regclass);


--
-- TOC entry 4855 (class 2604 OID 16443)
-- Name: entrenadores id_entrenador; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entrenadores ALTER COLUMN id_entrenador SET DEFAULT nextval('public.entrenadores_id_entrenador_seq'::regclass);


--
-- TOC entry 4861 (class 2604 OID 16483)
-- Name: horarios id_horario; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horarios ALTER COLUMN id_horario SET DEFAULT nextval('public.horarios_id_horario_seq'::regclass);


--
-- TOC entry 4870 (class 2604 OID 16547)
-- Name: marcas id_marca; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marcas ALTER COLUMN id_marca SET DEFAULT nextval('public.marcas_id_marca_seq'::regclass);


--
-- TOC entry 4872 (class 2604 OID 16566)
-- Name: permisos id_permiso; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.permisos ALTER COLUMN id_permiso SET DEFAULT nextval('public.permisos_id_permiso_seq'::regclass);


--
-- TOC entry 4864 (class 2604 OID 16511)
-- Name: productos id_producto; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.productos ALTER COLUMN id_producto SET DEFAULT nextval('public.productos_id_producto_seq'::regclass);


--
-- TOC entry 4868 (class 2604 OID 16533)
-- Name: proveedores id_proveedor; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.proveedores ALTER COLUMN id_proveedor SET DEFAULT nextval('public.proveedores_id_proveedor_seq'::regclass);


--
-- TOC entry 4848 (class 2604 OID 16392)
-- Name: roles id_rol; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN id_rol SET DEFAULT nextval('public.roles_id_rol_seq'::regclass);


--
-- TOC entry 4857 (class 2604 OID 16456)
-- Name: tiposmembresia id_membresia; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tiposmembresia ALTER COLUMN id_membresia SET DEFAULT nextval('public.tiposmembresia_id_membresia_seq'::regclass);


--
-- TOC entry 4850 (class 2604 OID 16401)
-- Name: usuarios id_usuario; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuarios ALTER COLUMN id_usuario SET DEFAULT nextval('public.usuarios_id_usuario_seq'::regclass);


--
-- TOC entry 5091 (class 0 OID 16491)
-- Dependencies: 236
-- Data for Name: Caracteristicas_de_productos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Caracteristicas_de_productos"  FROM stdin;
\.


--
-- TOC entry 5085 (class 0 OID 16462)
-- Dependencies: 230
-- Data for Name: Clases; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Clases"  FROM stdin;
\.


--
-- TOC entry 5076 (class 0 OID 16420)
-- Dependencies: 221
-- Data for Name: Clientes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Clientes"  FROM stdin;
\.


--
-- TOC entry 5079 (class 0 OID 16436)
-- Dependencies: 224
-- Data for Name: Entrenador; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Entrenador"  FROM stdin;
\.


--
-- TOC entry 5088 (class 0 OID 16476)
-- Dependencies: 233
-- Data for Name: Horarios; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Horarios"  FROM stdin;
\.


--
-- TOC entry 5110 (class 0 OID 16616)
-- Dependencies: 255
-- Data for Name: Mantenimiento; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Mantenimiento" (id_mantenimiento, equipo, fecha, tipo, descripcion, costo, estado, proximo_mantenimiento) FROM stdin;
3	maquina	2026-08-26 15:27:03.174	Preventivo	revision general	9000.00	Realizado	2026-09-26 15:27:03.137
2	caminadira	2026-08-17 15:15:13.44434	Preventivo	revison general	7000.00	Realizado	-infinity
1	caminadora	2026-08-17 15:03:29.514596	Preventivo	revision general	10000.00	Realizado	-infinity
\.


--
-- TOC entry 5100 (class 0 OID 16540)
-- Dependencies: 245
-- Data for Name: Marcas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Marcas"  FROM stdin;
\.


--
-- TOC entry 5106 (class 0 OID 16601)
-- Dependencies: 251
-- Data for Name: Membresia; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Membresia" (id_membresia, id_cliente, tipo, fecha_inicio, fecha_fin, precio, estado) FROM stdin;
1	4	Trimestral	2026-08-12	2026-09-12	2000.00	f
2	5	Anual	2026-08-03	2026-08-27	8000.00	t
4	12	Semestral	2026-08-03	2026-08-31	2000.00	t
5	9	Semestral	2026-08-25	2026-08-12	4000.00	t
6	3	Anual	2026-08-17	2027-08-17	900.00	t
\.


--
-- TOC entry 5082 (class 0 OID 16449)
-- Dependencies: 227
-- Data for Name: Menbresia; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Menbresia"  FROM stdin;
\.


--
-- TOC entry 5108 (class 0 OID 16609)
-- Dependencies: 253
-- Data for Name: PagoDiario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PagoDiario" (id_pago_diario, precio_entrada, fecha, metodo_pago, concepto, estado) FROM stdin;
1	200.00	2026-07-28	Efectivo	Entrada diaria	false
5	300.00	2026-07-28	Efectivo	Entrada diaria	Anulado
6	300.00	2026-07-28	Efectivo	Entrada diaria	Anulado
2	300.00	2026-07-28	Efectivo	Entrada diaria	Activo
3	100.00	2026-07-28	Transferencia	Entrada diaria	Activo
7	1000.00	2026-08-13	Transferencia	Entrada diaria	Activo
9	3000.00	2026-08-13	Efectivo	Entrada diaria	Activo
11	100.00	2026-08-17	Tarjeta	Entrada diaria	Activo
13	100.00	2026-08-27	Efectivo	Entrada diaria	Activo
14	100.00	2026-08-27	Efectivo	Entrada diaria	Activo
15	100.00	2026-08-17	Transferencia	Entrada diaria	Activo
16	100.00	2026-08-17	Transferencia	Entrada diaria	Activo
\.


--
-- TOC entry 5094 (class 0 OID 16504)
-- Dependencies: 239
-- Data for Name: Productos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Productos"  FROM stdin;
\.


--
-- TOC entry 5097 (class 0 OID 16526)
-- Dependencies: 242
-- Data for Name: Proveedores; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Proveedores"  FROM stdin;
\.


--
-- TOC entry 5093 (class 0 OID 16495)
-- Dependencies: 238
-- Data for Name: categoriasproductos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.categoriasproductos (id_categoria, nombre, descripcion, estado) FROM stdin;
1	Suero de Leche (Whey Protein)	Incluye concentrada (WPC), aislada (WPI) e hidrolizada.	t
2	Proteína de Caseína	Proteína de digestión lenta derivada de la leche.	t
3	Proteínas Veganas	Proteínas de origen vegetal.	t
4	Proteína de Carne	Proteína de carne (Beef Protein).	t
5	Proteínas Cero Carbohidratos / Cero Grasa	Proteínas formuladas con cero carbohidratos o cero grasa.	t
6	Ganadores de Peso (Mass Gainers)	Suplementos diseñados para aumentar la ingesta calórica y favorecer la ganancia de peso.	t
\.


--
-- TOC entry 5087 (class 0 OID 16467)
-- Dependencies: 232
-- Data for Name: clases; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clases (id_clase, nombre, descripcion, cupo_maximo, estado) FROM stdin;
\.


--
-- TOC entry 5078 (class 0 OID 16424)
-- Dependencies: 223
-- Data for Name: clientes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.clientes (id_cliente, nombre, apellido, cedula, telefono, correo, direccion, fecha_nacimiento, sexo, foto, fecha_registro, estado, id_usuario) FROM stdin;
5	livi	cabrera	758598696	758598696	kj@gamil.com	zurza	1999-05-02		C:\\Users\\Cuere\\Downloads\\grey's anatomy 2.jpeg	2026-08-08	t	\N
4	monchi	ramirez	2894045	2894045	monchi@gmail.com	sanchez	1961-07-09	Femenino		2026-08-08	t	\N
7	nayi	cabrera	8484859000	8484859000	nayi@gmail.com	zurza	2002-04-02	Femenino	C:\\Users\\Cuere\\Downloads\\grey's anatomy.jpeg	2026-08-08	t	11
1	esthela	perez	1-3495-09856	26748495	holamundpo@gmail.com	sanchez 	1999-08-02	Femenino	C:\\Users\\Cuere\\Downloads\\grey's anatomy 4.jpg	2026-08-08	t	7
9	lola	mundo	28920333	28920333	lolamundo@gmail.com	los prado	2026-01-21	Masculino		2026-08-09	t	\N
3	grisa	perez	0393984	0393984	jum@gmail.com	calle sol	1999-11-30	Femenino	C:\\Users\\Cuere\\Downloads\\solo levelingn2.jpeg	2026-08-08	t	\N
10	mundo	gira	759484342	64750563	nose@gmail.com	mks	2026-08-05	Masculino		2026-08-09	t	0
11	mundo	gira	1234567890	0987654321	mundogira@gmail.com	no se 	2026-08-09	Masculino		2026-08-09	t	0
12	amor	no se	2829347	12345567	amor@gmail.com	el mundo	2026-07-15	Otro	C:\\Users\\Cuere\\Downloads\\tarea de scilab de quijada.jpeg	2026-08-10	t	0
13	griselda	de elon 	837647483	809 872 2360	grisa@gmail.com	sanchez	1999-11-30	Femenino		2026-08-17	t	0
\.


--
-- TOC entry 5081 (class 0 OID 16440)
-- Dependencies: 226
-- Data for Name: entrenadores; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.entrenadores (id_entrenador, nombre, apellido, telefono, correo, especialidad, horario, estado, foto) FROM stdin;
2	keuri	perez	75757860	keuirigmail.com	pecho	06:00 AM - 07:00 PM	f	
1						 - 	f	\N
4	firutt	de leon	7485903	firutt@gmail.com	comer	10:00 AM - 12:00 PM	f	C:\\Users\\Cuere\\Downloads\\logo de inicio 2.jpg
5	manuel	cabrera	689 890 8765	manuel@gmail.com	cardio	07:00 AM - 10:00 AM	f	\N
\.


--
-- TOC entry 5090 (class 0 OID 16480)
-- Dependencies: 235
-- Data for Name: horarios; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.horarios (id_horario, id_clase, dia_semana, hora_inicio, hora_fin) FROM stdin;
\.


--
-- TOC entry 5102 (class 0 OID 16544)
-- Dependencies: 247
-- Data for Name: marcas; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.marcas (id_marca, nombre, descripcion, estado) FROM stdin;
1	Optimum Nutrition (ON)	Gold Standard 100% Whey.	t
2	Dymatize	ISO 100.	t
3	Isopure	Zero Carb / Low Carb.	t
4	MyProtein	Impact Whey Protein.	t
5	MuscleTech	Nitro-Tech.	t
6	BSN	Syntha-6.	t
7	Birdman	Falcon Protein.	t
8	Sascha Fitness	Hydrolyzed Whey Protein Isolate.	t
\.


--
-- TOC entry 5103 (class 0 OID 16561)
-- Dependencies: 248
-- Data for Name: permisos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.permisos (id_permiso, id_rol, modulo, ver, crear, editar, eliminar) FROM stdin;
38	14	Clientes	f	f	f	f
39	14	Usuarios	f	f	f	f
40	14	Roles	f	f	f	f
41	14	Entrenadores	t	t	t	f
42	14	Membresias	f	f	f	f
43	14	Productos	f	f	f	f
44	14	Proveedores	f	f	f	f
23	2	Inicio	t	f	f	f
24	3	Inicio	t	f	f	f
25	13	Inicio	t	f	f	f
26	15	Inicio	t	f	f	f
27	14	Inicio	t	f	f	f
28	17	Inicio	t	f	f	f
29	18	Inicio	t	f	f	f
31	2	Permisos	f	f	f	f
32	3	Permisos	f	f	f	f
33	13	Permisos	f	f	f	f
34	15	Permisos	f	f	f	f
35	14	Permisos	f	f	f	f
36	17	Permisos	f	f	f	f
37	18	Permisos	f	f	f	f
22	1	Inicio	t	t	t	t
30	1	Permisos	t	t	t	t
94	2	Clientes	t	t	t	f
95	2	Usuarios	f	f	f	f
96	2	Roles	f	f	f	f
97	2	Entrenadores	f	f	f	f
98	2	Membresias	f	f	f	f
99	2	Productos	f	f	f	f
100	2	Proveedores	f	f	f	f
1	1	Clientes	t	t	t	t
2	1	Usuarios	t	t	t	t
3	1	Roles	t	t	t	t
4	1	Entrenadores	t	t	t	t
5	1	Membresias	t	t	t	t
6	1	Productos	t	t	t	t
7	1	Proveedores	t	t	t	t
8	17	Clientes	f	f	f	f
9	17	Usuarios	f	f	f	f
10	17	Roles	f	f	f	f
11	17	Entrenadores	f	f	f	f
12	17	Membresias	f	f	f	f
13	17	Productos	f	f	f	f
14	17	Proveedores	f	f	f	f
\.


--
-- TOC entry 5096 (class 0 OID 16508)
-- Dependencies: 241
-- Data for Name: productos; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.productos (id_producto, codigo, nombre, descripcion, id_categoria, precio_compra, precio_venta, stock, stock_minimo, imagen, estado, id_marca) FROM stdin;
1	PROT001	Whey Protein	Proteína de suero	3	100.00	50.00	30	20		t	1
3	descuentoEsther	proteina	buena	1	97.00	27.00	17	6	C:\\Users\\Cuere\\Downloads\\WhatsApp Image 2026-08-07 at 2.36.25 PM (1).jpeg	t	5
2	husdjnsjdc	dsjeuhyufw	no se	5	10.00	5.00	8	1	C:\\Users\\Cuere\\Downloads\\tarea de scilab de quijada.jpeg	t	8
\.


--
-- TOC entry 5099 (class 0 OID 16530)
-- Dependencies: 244
-- Data for Name: proveedores; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.proveedores (id_proveedor, nombre, telefono, correo, direccion, estado, empresa) FROM stdin;
1	sergio	76879069	sergio@gmail.com	en el mundo	f	los minier
2	juan	002093	juan@gmail.com	kkddwjs	t	mundo
4	fsnjcn	6773839	mkcmkd@gmail.com	kjsanjdkjd	t	smdcskv
\.


--
-- TOC entry 5073 (class 0 OID 16389)
-- Dependencies: 218
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.roles (id_rol, nombre, descripcion, estado) FROM stdin;
1	Administrador	Acceso completo al sistema	t
2	Recepcionista	Gestiona clientes y cobros	t
3	Entrenador	Consulta clientes y clases	t
13	Supervisor	Supervisa el gimnasio	f
15	Recepcionista General	Gestiona clientes y cobros	t
14	 Recepcionista Principal	Gestiona clientes y cobros	t
17	Cliente	Cliente	t
18	Usuario	Usuario	t
20	Conserje	Limpiar 	t
\.


--
-- TOC entry 5084 (class 0 OID 16453)
-- Dependencies: 229
-- Data for Name: tiposmembresia; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tiposmembresia (id_membresia, nombre, descripcion, duracion_dias, precio, estado) FROM stdin;
\.


--
-- TOC entry 5075 (class 0 OID 16398)
-- Dependencies: 220
-- Data for Name: usuarios; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.usuarios (id_usuario, nombre, usuario, contrasena, id_rol, estado) FROM stdin;
1	Administrador	admin	123456	1	t
5	estherdeleon	esther	1234	14	t
7	esthelaperez	esthela	123	17	t
10	jhcvhdkad	hola	4321	1	t
11	nayelis cabrera	nayi	0812	17	t
12	lolamundo	lola	0000	17	t
14	mundogira	mundo	1111	17	t
15	amor nose	amor	112233	17	t
16	Phillip Garcia	phillip	2024	3	t
17	grisa de leon	grisa	6666	18	t
18	rudi sosa	rudi	7777	20	f
19	estemundo	este	0987	2	f
21	klkmundo	klk	klk	2	f
22	pruebanose	prueba	hola	14	f
23	firutt de leon	firutt	firutt	2	f
25	lloronmundo	lloron	lloron	2	f
26	utesa sede	utesa	utesa	2	f
27	isaiashola	isaias	mundo	14	f
29	franklk	fran	1234567	14	f
31	angel marrero	angel	5678	14	t
\.


--
-- TOC entry 5131 (class 0 OID 0)
-- Dependencies: 254
-- Name: Mantenimiento_id_mantenimiento_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Mantenimiento_id_mantenimiento_seq"', 4, true);


--
-- TOC entry 5132 (class 0 OID 0)
-- Dependencies: 250
-- Name: Membresia_id_membresia_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Membresia_id_membresia_seq"', 6, true);


--
-- TOC entry 5133 (class 0 OID 0)
-- Dependencies: 252
-- Name: PagoDiario_id_pago_diario_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PagoDiario_id_pago_diario_seq"', 16, true);


--
-- TOC entry 5134 (class 0 OID 0)
-- Dependencies: 237
-- Name: categoriasproductos_id_categoria_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categoriasproductos_id_categoria_seq', 6, true);


--
-- TOC entry 5135 (class 0 OID 0)
-- Dependencies: 231
-- Name: clases_id_clase_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clases_id_clase_seq', 1, false);


--
-- TOC entry 5136 (class 0 OID 0)
-- Dependencies: 222
-- Name: clientes_id_cliente_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.clientes_id_cliente_seq', 13, true);


--
-- TOC entry 5137 (class 0 OID 0)
-- Dependencies: 225
-- Name: entrenadores_id_entrenador_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.entrenadores_id_entrenador_seq', 5, true);


--
-- TOC entry 5138 (class 0 OID 0)
-- Dependencies: 234
-- Name: horarios_id_horario_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.horarios_id_horario_seq', 1, false);


--
-- TOC entry 5139 (class 0 OID 0)
-- Dependencies: 246
-- Name: marcas_id_marca_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.marcas_id_marca_seq', 8, true);


--
-- TOC entry 5140 (class 0 OID 0)
-- Dependencies: 249
-- Name: permisos_id_permiso_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.permisos_id_permiso_seq', 107, true);


--
-- TOC entry 5141 (class 0 OID 0)
-- Dependencies: 240
-- Name: productos_id_producto_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.productos_id_producto_seq', 4, true);


--
-- TOC entry 5142 (class 0 OID 0)
-- Dependencies: 243
-- Name: proveedores_id_proveedor_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.proveedores_id_proveedor_seq', 4, true);


--
-- TOC entry 5143 (class 0 OID 0)
-- Dependencies: 217
-- Name: roles_id_rol_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_id_rol_seq', 20, true);


--
-- TOC entry 5144 (class 0 OID 0)
-- Dependencies: 228
-- Name: tiposmembresia_id_membresia_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tiposmembresia_id_membresia_seq', 1, false);


--
-- TOC entry 5145 (class 0 OID 0)
-- Dependencies: 219
-- Name: usuarios_id_usuario_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.usuarios_id_usuario_seq', 31, true);


--
-- TOC entry 4921 (class 2606 OID 16624)
-- Name: Mantenimiento Mantenimiento_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Mantenimiento"
    ADD CONSTRAINT "Mantenimiento_pkey" PRIMARY KEY (id_mantenimiento);


--
-- TOC entry 4917 (class 2606 OID 16607)
-- Name: Membresia Membresia_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Membresia"
    ADD CONSTRAINT "Membresia_pkey" PRIMARY KEY (id_membresia);


--
-- TOC entry 4919 (class 2606 OID 16614)
-- Name: PagoDiario PagoDiario_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PagoDiario"
    ADD CONSTRAINT "PagoDiario_pkey" PRIMARY KEY (id_pago_diario);


--
-- TOC entry 4903 (class 2606 OID 16503)
-- Name: categoriasproductos categoriasproductos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categoriasproductos
    ADD CONSTRAINT categoriasproductos_pkey PRIMARY KEY (id_categoria);


--
-- TOC entry 4899 (class 2606 OID 16475)
-- Name: clases clases_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clases
    ADD CONSTRAINT clases_pkey PRIMARY KEY (id_clase);


--
-- TOC entry 4891 (class 2606 OID 16435)
-- Name: clientes clientes_cedula_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clientes
    ADD CONSTRAINT clientes_cedula_key UNIQUE (cedula);


--
-- TOC entry 4893 (class 2606 OID 16433)
-- Name: clientes clientes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.clientes
    ADD CONSTRAINT clientes_pkey PRIMARY KEY (id_cliente);


--
-- TOC entry 4895 (class 2606 OID 16448)
-- Name: entrenadores entrenadores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entrenadores
    ADD CONSTRAINT entrenadores_pkey PRIMARY KEY (id_entrenador);


--
-- TOC entry 4901 (class 2606 OID 16485)
-- Name: horarios horarios_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horarios
    ADD CONSTRAINT horarios_pkey PRIMARY KEY (id_horario);


--
-- TOC entry 4911 (class 2606 OID 16552)
-- Name: marcas marcas_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.marcas
    ADD CONSTRAINT marcas_pkey PRIMARY KEY (id_marca);


--
-- TOC entry 4913 (class 2606 OID 16572)
-- Name: permisos permisos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.permisos
    ADD CONSTRAINT permisos_pkey PRIMARY KEY (id_permiso);


--
-- TOC entry 4905 (class 2606 OID 16520)
-- Name: productos productos_codigo_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_codigo_key UNIQUE (codigo);


--
-- TOC entry 4907 (class 2606 OID 16518)
-- Name: productos productos_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT productos_pkey PRIMARY KEY (id_producto);


--
-- TOC entry 4909 (class 2606 OID 16538)
-- Name: proveedores proveedores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.proveedores
    ADD CONSTRAINT proveedores_pkey PRIMARY KEY (id_proveedor);


--
-- TOC entry 4883 (class 2606 OID 16396)
-- Name: roles roles_nombre_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_nombre_key UNIQUE (nombre);


--
-- TOC entry 4885 (class 2606 OID 16394)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id_rol);


--
-- TOC entry 4897 (class 2606 OID 16461)
-- Name: tiposmembresia tiposmembresia_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tiposmembresia
    ADD CONSTRAINT tiposmembresia_pkey PRIMARY KEY (id_membresia);


--
-- TOC entry 4915 (class 2606 OID 16583)
-- Name: permisos uq_permisos_rol_modulo; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.permisos
    ADD CONSTRAINT uq_permisos_rol_modulo UNIQUE (id_rol, modulo);


--
-- TOC entry 4887 (class 2606 OID 16404)
-- Name: usuarios usuarios_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_pkey PRIMARY KEY (id_usuario);


--
-- TOC entry 4889 (class 2606 OID 16406)
-- Name: usuarios usuarios_usuario_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_usuario_key UNIQUE (usuario);


--
-- TOC entry 4923 (class 2606 OID 16486)
-- Name: horarios fk_horario_clase; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.horarios
    ADD CONSTRAINT fk_horario_clase FOREIGN KEY (id_clase) REFERENCES public.clases(id_clase);


--
-- TOC entry 4926 (class 2606 OID 16577)
-- Name: permisos fk_permisos_roles; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.permisos
    ADD CONSTRAINT fk_permisos_roles FOREIGN KEY (id_rol) REFERENCES public.roles(id_rol);


--
-- TOC entry 4924 (class 2606 OID 16521)
-- Name: productos fk_producto_categoria; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT fk_producto_categoria FOREIGN KEY (id_categoria) REFERENCES public.categoriasproductos(id_categoria);


--
-- TOC entry 4925 (class 2606 OID 16553)
-- Name: productos fk_producto_marca; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.productos
    ADD CONSTRAINT fk_producto_marca FOREIGN KEY (id_marca) REFERENCES public.marcas(id_marca);


--
-- TOC entry 4922 (class 2606 OID 16407)
-- Name: usuarios fk_usuario_rol; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT fk_usuario_rol FOREIGN KEY (id_rol) REFERENCES public.roles(id_rol);


-- Completed on 2026-08-25 18:07:18

--
-- PostgreSQL database dump complete
--

\unrestrict htLIjReWPLMQQFNMkarEsg8V7R4k83BtvsXaFAxLFFxQcLlE64NfqWCbVwDUCRO

