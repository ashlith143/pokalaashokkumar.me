# System Design

Questions and answers about designing scalable .NET systems.

### What is system design in the context of software engineering?
System design involves defining the architecture, components, and data flow of an application so it meets requirements for scalability, reliability, and maintainability.

### How would you design a logging service for multiple microservices?
Use a centralized logging store like Elasticsearch or Serilog sinks that collect logs from each service. Each service writes structured logs asynchronously, and a dashboard like Kibana allows searching across all logs.

### What is horizontal scaling versus vertical scaling?
Horizontal scaling adds more servers or service instances to handle load, while vertical scaling increases the resources (CPU, memory) of an existing server. Cloud environments often rely on horizontal scaling for resilience.

### Explain the role of a message queue in distributed systems.
Message queues like RabbitMQ or Azure Service Bus decouple services by allowing them to send and receive messages asynchronously. This helps smooth spikes in load and allows services to process tasks independently.

### How can caching improve the performance of a web API?
Storing frequently accessed data in a cache like Redis reduces database load and speeds up responses. Cache entries should be invalidated or refreshed when underlying data changes.

### What is a CDN and when should you use one?
A Content Delivery Network distributes static assets (images, scripts, CSS) across servers closer to users. CDNs reduce latency and load on your main servers, improving performance for global audiences.

## Core Building Blocks

### 1️⃣ Load Balancers

**What it is**
A load balancer distributes incoming traffic across multiple backend servers to ensure:
- No single server is overwhelmed
- High availability (if one server fails, traffic goes to others)
- Better latency and performance

**Types of Load Balancers**

#### Layer 4 (Transport Layer)
Works at TCP/UDP level and balances traffic based on IP address and port. No inspection of HTTP headers.

**When to use:** when low latency is critical or when handling raw TCP/UDP connections such as WebSocket-based chat.

**Example:** AWS Network Load Balancer (NLB), HAProxy in TCP mode.

#### Layer 7 (Application Layer)
Works at the HTTP/HTTPS level and can inspect URLs, cookies and headers. Supports advanced routing rules (for example routing `/api` to API servers and `/static` to a CDN).

**When to use:** when you need smart routing or cookie/session stickiness.

**Example:** AWS Application Load Balancer (ALB), Nginx acting as a reverse proxy and load balancer.

**Load Balancing Algorithms**

| Algorithm | Description | When to use |
| --- | --- | --- |
| Round Robin | Each request goes to the next server | Evenly distributed traffic |
| Least Connections | Send to the server with the fewest active connections | Long-lived connections such as chat or streaming |
| IP Hash | Same client IP always goes to the same server | Sticky sessions such as shopping carts |

**High-Level Architecture Example**
```
Client Requests → Load Balancer → Multiple Web Servers → DB
```

**Key Benefits**
- High availability
- Scalability (horizontal scaling)
- Better response times
- Fault tolerance

**Drawbacks**
- Single point of failure if not configured with redundancy
- Complexity in sticky session handling (Layer 7)

### 2️⃣ Caching

**What it is**
A technique to store frequently accessed data in memory (RAM) for faster retrieval.

**Why use caching?**
- Reduce latency and speed up responses
- Offload the database
- Handle read-heavy traffic

**Types of Caching**
- Client-side cache (browser cache)
- Content Delivery Network (CDN) for static resources
- Server-side cache with tools like Redis or Memcached
- Application-level cache within the process

**Caching Strategies**

| Strategy | Description | Use case |
| --- | --- | --- |
| Read-through | App reads from cache; if not found, loads from DB and updates cache | Common for frequently read data |
| Write-through | App writes to both cache and DB | Keeps cache always fresh |
| Write-around | App writes only to DB; cache updated on next read | Good if writes are rare but reads are frequent |
| Cache-aside | App loads cache only on a cache miss | Most common pattern |

**Eviction Policies**
- LRU (Least Recently Used)
- LFU (Least Frequently Used)
- FIFO (First In, First Out)

**When to use caching?**
- Data is read frequently but rarely changes (product catalog, user profile)
- Data is expensive to compute (leaderboards)
- API responses with static data

**When not to use caching?**
- Data changes frequently and must be strongly consistent (bank transactions)
- Small datasets where caching offers little benefit
- Risk of stale data is unacceptable

**Real-world Examples**
- Instagram caches feed data in Redis
- Amazon caches product prices to reduce DB load
- Twitter caches tweet timelines

### 3️⃣ Database Basics: SQL vs NoSQL

**Relational Databases (SQL)**
- Structured schema
- ACID transactions
- Support for joins and complex queries
- Examples: MySQL, PostgreSQL, Oracle

**When to use:** financial data, complex relational queries, strong consistency requirements.

**NoSQL Databases**

| Type | Example | Use case |
| --- | --- | --- |
| Document Store | MongoDB | JSON-like data, flexible schema |
| Key-Value | Redis, DynamoDB | Session data, caching |
| Column Store | Cassandra | Time-series or large datasets |
| Graph DB | Neo4j | Social networks, fraud detection |

**When to use:** flexible schema, high scalability, eventual consistency is acceptable.

**Trade-offs**

| SQL | NoSQL |
| --- | --- |
| Strong consistency | Eventual consistency often |
| Schema rigidity | Flexible schema |
| Complex joins | Joins usually avoided |

### 4️⃣ Sharding

**What it is**
Breaking a large dataset into smaller partitions (shards) stored on different machines.

**Why?**
- Improve scalability by distributing load
- Parallelize reads and writes

**Example:** Facebook shards user data by user_id, MongoDB uses shard keys.

**Challenges**
- Cross-shard queries become complex
- Rebalancing when adding new shards
- Consistent hashing helps distribute data evenly

### 5️⃣ Replication

**What it is**
Creating copies of data across multiple servers.

**Why?**
- High availability (read from replica if primary fails)
- Scalability for read-heavy apps

**Types**
- Synchronous: immediate consistency but slower writes
- Asynchronous: eventual consistency but faster writes

**Example:** MySQL master-slave replication, Cassandra’s multi-node replication

### 6️⃣ Message Queues

**What it is**
A buffer for asynchronous tasks between producer and consumer.

**Why?**
- Smooth out traffic spikes
- Decouple components (for example order service → payment service)
- Retry failed jobs

**Examples:** RabbitMQ, Kafka

### 7️⃣ CDN

**What it is**
A global network of servers caching static content near users.

**Why?**
- Reduce latency for page loads
- Offload origin servers

**Example:** Cloudflare, Akamai for images, CSS and videos

### 8️⃣ CAP Theorem

In a distributed system you can only pick two of the following three properties:

| Property | Meaning |
| --- | --- |
| Consistency | All clients see the same data at the same time |
| Availability | Every request gets a response (not necessarily the latest) |
| Partition Tolerance | System works even if the network is split |

**Examples:** MongoDB leans toward CP while DynamoDB is AP.

### 9️⃣ Consistent Hashing

**What it is**
A technique for distributing data evenly across a dynamic set of servers.

**Why use it?**
- Avoids data movement when servers are added or removed
- Reduces cache misses or rebalancing overhead

**How it works**
- Hash ring concept: hash each server and key onto a circle
- Each key stored on the first server clockwise on the ring
- Adding a server only moves a small portion of keys

**When to use:** caching systems like Redis clusters or distributed databases such as Cassandra or DynamoDB.

### 🔟 Eventual Consistency vs Strong Consistency

**Strong Consistency** – every read sees the latest write immediately. Used in traditional SQL databases where financial transactions require accuracy.

**Eventual Consistency** – data becomes consistent over time. Used in systems like DynamoDB or Cassandra where high availability is more important.

### 1️⃣1️⃣ API Gateway

A single entry point for all client requests in a microservices architecture.

**Key roles**
- Authentication and authorization
- Rate limiting
- Request routing to the correct microservice
- Response transformation

**Examples:** AWS API Gateway, Netflix Zuul, Kong.

### 1️⃣2️⃣ Microservices vs Monoliths

**Monolith** – a single deployable unit that is tightly coupled. Simple at small scale but harder to evolve.

**Microservices** – each service is independently deployable and scalable. Better when teams need to work on separate features.

**When to use:** monolith for MVP/startups, microservices for scaling teams and features.

### 1️⃣3️⃣ Service Discovery

Mechanism for services to dynamically find and communicate with each other.

**Why?** in the cloud, service instances change frequently. Hard-coded addresses are not feasible.

**Tools:** Eureka, Consul, or Kubernetes DNS.

### 1️⃣4️⃣ Data Modeling (Normalization vs Denormalization)

**Normalization** – avoid data duplication. Good for write-heavy transactional systems.

**Denormalization** – duplicate data to avoid expensive joins. Good for read-heavy workloads.

**Example:** e-commerce product information might be denormalized for faster search.

### 1️⃣5️⃣ Idempotency

An operation that can be repeated safely without unintended effects. Crucial for unreliable networks or payment retries.

**Example:** payment APIs use idempotency keys; RESTful `PUT` is idempotent while `POST` is not.

### 1️⃣6️⃣ Distributed Transactions

**The Problem**
Updating multiple resources or services atomically (order plus payment).

**Solutions**
- **2-Phase Commit (2PC)** – coordinator asks participants to prepare then commit if all succeed. Blocking and not very scalable.
- **Saga Pattern** – sequence of local transactions with events. If failure occurs, run compensating transactions.

**Example:** booking systems where you reserve a flight and a hotel together.

### 1️⃣7️⃣ Observability

Includes monitoring, logging and tracing so you can debug issues faster and track performance.

**Tools:** Prometheus and Grafana for metrics, the ELK stack for logs, Jaeger or Zipkin for tracing.

### 1️⃣8️⃣ Security in System Design

- **Authentication** – verifying user identity (OAuth2, JWT)
- **Authorization** – determining what a user can do (RBAC)
- **Encryption** – data-at-rest with AES and in-transit with TLS
- **Input Validation** – avoid SQL injection and XSS
- **Auditing** – track changes for sensitive systems

### 1️⃣9️⃣ Scalability Patterns

- **Vertical Scaling** – bigger machines
- **Horizontal Scaling** – add more servers, often with a load balancer
- **Read Replicas** – scale reads for read-heavy workloads
- **Fan-out** – push updates to many destinations
- **Auto-scaling** – dynamically add or remove instances (AWS ASG, Kubernetes HPA)

### 2️⃣0️⃣ Circuit Breakers & Retry Patterns

**Circuit Breaker** – stops repeated failed calls to a broken service so the system can recover.

**Retry Pattern** – automatically retry with backoff for temporary failures.

**Tools:** Netflix Hystrix, Resilience4j.

### 2️⃣1️⃣ Indexing & Query Optimization

**Indexing** speeds up data retrieval. B-tree indexes are common in relational databases while LSM trees appear in NoSQL systems like Cassandra.

**Query Optimization** – examine query plans (e.g., using `EXPLAIN`) and avoid `SELECT *` in production code.

### 2️⃣2️⃣ Putting it Together – Example Flow

```
Client → API Gateway → Load Balancer → Microservices
  ↳ Service Discovery
  ↳ Redis for Caching
  ↳ Message Queue for async tasks
  ↳ DB with Sharding & Replication
  ↳ Observability stack
  ↳ Circuit Breakers to protect dependencies
```

## HTTP, HTTPS and TLS

### HTTP vs HTTPS

**HTTP** is plain text and vulnerable to eavesdropping. **HTTPS** is HTTP over TLS and encrypts the channel to protect data integrity and confidentiality.

### SSL and TLS

SSL is the older protocol and is now obsolete. TLS 1.2 and 1.3 are the modern standards that provide encryption, integrity via HMAC, and authentication via certificates.

**Simplified TLS Handshake**
1. Client hello with supported versions and ciphers
2. Server hello with chosen cipher and its certificate
3. Client verifies the certificate via the CA chain
4. Key exchange occurs (RSA or Diffie-Hellman)
5. Encrypted communication begins

### Certificates and Certificate Authorities

A certificate binds a domain name to a public key and is signed by a trusted certificate authority (CA). Browsers trust root CAs which in turn sign intermediate CAs and finally your server certificate.

### Creating and Using Certificates

```bash
# 1. Generate a private key
openssl genrsa -out server.key 2048

# 2. Create a certificate signing request
openssl req -new -key server.key -out server.csr
```
Send the CSR to a CA (for example Let’s Encrypt or DigiCert) which verifies domain ownership and returns a signed certificate.

Configure your web server with the certificate and key:

```nginx
server {
    listen 443 ssl;
    server_name example.com;
    ssl_certificate /path/to/server.crt;
    ssl_certificate_key /path/to/server.key;
    ssl_protocols TLSv1.2 TLSv1.3;
}
```

Automate renewal with tools like Certbot:

```bash
sudo certbot renew
```

**Best Practices**
- Use TLS 1.2 or 1.3 only
- Use strong ciphers (AES-256, ChaCha20)
- Rotate and renew certificates regularly
- Set HSTS headers so browsers always use HTTPS
- Consider certificate pinning for critical APIs

### Common Interview Questions
- What is the difference between SSL and TLS?
- How does HTTPS establish a secure connection?
- What is a certificate chain?
- How do you handle expired or revoked certificates?
- What is the difference between a self-signed and a CA-signed certificate?

